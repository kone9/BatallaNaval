using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;

public class CuadriculaDeColisionesJugandoNivel : MonoBehaviourPunCallbacks,Photon.Pun.IPunObservable
{
    GameHandlerRED _GamehandlerRED;

     //AUDIO globales
    public GameObject[] audio_miss;//sonido errar disparo

    private MeshRenderer mymesh;
    private BoxCollider miCollyder;

    public MeshRenderer CuadriculaEnemigoSuperior;

    
    private void Awake()
    {
        _GamehandlerRED = FindObjectOfType<GameHandlerRED>();
        audio_miss = GameObject.FindGameObjectsWithTag("miss_audio");//sonido errar disparo
        mymesh = GetComponent<MeshRenderer>();
        miCollyder = GetComponent<BoxCollider>();
        CuadriculaEnemigoSuperior = GameObject.Find("A" + this.gameObject.name).GetComponent<MeshRenderer>();
    }

    private void OnMouseDown()
    {
        if(_GamehandlerRED.GetPuedoPresionarBoton())//si puedo presionar boton
        {
            StartCoroutine("PresioneGrilla");
        }
    }

    /// <summary>Desactivo todo lo relacionado a la cuadricula y activa turno enemigo</summary>
    IEnumerator PresioneGrilla()
    {
        mymesh.enabled = false;//desactivo esta cuadricula
        miCollyder.enabled = false;//desactivo la colision de esta cuadricula
        DeshabilitarCuadriculaPhoton();//desactivar cuadricula enemigo parte superior

        audio_miss[1].GetComponent<AudioSource>().Play();//activo sonido errar disparo
        _GamehandlerRED.SetPuedoPresionarBoton(false);//no puedo volver a presionar los botones
        yield return new WaitForSeconds(0.4f);
        _GamehandlerRED.IsTurnoEnemigo();//es turno de enemigo
    }

     /// <summary>Desactivo o activa todo lo relacionado a la cuadricula superior. Si uso otros tendría que deshabilitarse la cuadricula superior del otro</summary>
    private void DeshabilitarCuadriculaPhoton()
    {
        photonView.RPC("DeshabilitarCuadriculaEnemigoSuperior", //Nombre de la función que es llamada localmente
                RpcTarget.OthersBuffered,//para llamar a la función en Otros
                false//saca el tablero de color rojo del fondo
            ); 
    }

     /// <summary>Para desactivar cuadricula usando Photon</summary>
    [PunRPC]
    public void DeshabilitarCuadriculaEnemigoSuperior(bool deshabilitarCuadricula)
    {
        CuadriculaEnemigoSuperior.enabled = deshabilitarCuadricula;//deshabilito cuadricula pero solo lo hace el enemigo
        audio_miss[1].GetComponent<AudioSource>().Play();//activo sonido errar disparo pero solo lo escucha el enemigo
    }

    //estoy usando la interface por eso llamo a esto obligatoriamente
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}
