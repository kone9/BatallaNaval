using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public class CharacterTestLuegoBorrar : MonoBehaviourPunCallbacks
{
    public ControladorDeJugador _ControladorDeJugador;
    public MoveAndRotateBoat _moveAndRotateBoat;
    public float distanciaDisparo = 1.2f;

    public GameObject proyectil;
   
    void deshabilitarSinoSoyYo()
    {
        if(!photonView.IsMine)//sino soy yo,osea soy un avatar no necesito estos controladores solo deshabilito sino hay bug
        {
            // Destroy(this);
            this.enabled = false;
            _ControladorDeJugador.enabled = false;
            _moveAndRotateBoat.enabled = false;
            // Destroy(_ControladorDeJugador);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        deshabilitarSinoSoyYo();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Horizontal"))
        {
            // disparar();
            // photonView.RPC("disparar", RpcTarget.All);
            photonView.RPC("disparar", RpcTarget.All);
        }
    }

    [PunRPC]
    void disparar()
    {
        GameObject bala = Instantiate(proyectil);
        bala.transform.position = this.transform.position + this.transform.forward * distanciaDisparo;
        bala.transform.forward = this.transform.forward;
    }




}
