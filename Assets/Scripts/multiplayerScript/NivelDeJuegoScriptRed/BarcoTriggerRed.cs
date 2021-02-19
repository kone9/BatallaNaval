using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public class BarcoTriggerRed : MonoBehaviourPunCallbacks
{
    public GameObject fuego;
    public BoxCollider _BoxCollider;

    private PhotonView _photonView;
    GameHandlerRED _GameHandlerRED;
    
    private void Awake() {
        _BoxCollider = GetComponent<BoxCollider>();
        _GameHandlerRED = FindObjectOfType<GameHandlerRED>();
        _photonView = GetComponent<PhotonView>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnMouseDown() 
    { 
        if(_GameHandlerRED.GetPuedoPresionarBoton())
        {
            instanciarFuego(this.transform.position);//instancio fuego en esta posición


            _photonView.RPC("InstanciarFuegoEnMisBarcos", //Nombre de la función que es llamada localmente
                RpcTarget.OthersBuffered,//para obtener los parámetros o ejecutar en otros
                this.transform.position//posicion de este gameobject para usar en la posición de mis barcos en la pantalla de arriba
            ); 
            
            _GameHandlerRED.cantidadDeAciertosJugador += 1;

            print("TENDRIA QUE INSTANCIAR EL FUEGO");
        }
        if(_GameHandlerRED.cantidadDeAciertosJugador == 21)
        {
            _GameHandlerRED.GameOverWinner();
        }

    }



    [PunRPC]
    void InstanciarFuegoEnMisBarcos(Vector3 posicionInicialFuego)
    {
        Vector3 fuegoPosicionEnEnemigo = posicionInicialFuego;
        fuegoPosicionEnEnemigo.z += 250;
        instanciarFuego(fuegoPosicionEnEnemigo);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "cuadriculaColision")
        {
            other.gameObject.SetActive(false);
            // print("la grilla colisiono con un barco");
        }
    }


    private void instanciarFuego(Vector3 posicionInicialFuego)
    {
        GameObject fuegoInstance = Instantiate(fuego);
        //fuegoInstance.transform.SetParent(this.gameObject.transform);
        fuegoInstance.transform.position = posicionInicialFuego;
        _BoxCollider.enabled = false;
    }
}
