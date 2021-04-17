using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;

public class CuadriculaDeColisionesJugandoNivel : MonoBehaviourPunCallbacks,Photon.Pun.IPunObservable
{
    GameHandlerRED _GamehandlerRED;

     //AUDIO globales
    public GameObject[] miss_audio_jugador;//sonido errar disparo jugador
    public GameObject[] miss_1_enemy;//sonido errar disparo enemigo 

    private MeshRenderer mymesh;
    private BoxCollider miCollyder;

    public MeshRenderer CuadriculaEnemigoSuperior;

    
    private void Awake()
    {
        _GamehandlerRED = FindObjectOfType<GameHandlerRED>();
        miss_audio_jugador = GameObject.FindGameObjectsWithTag("miss_audio_jugador");//sonido errar disparo jugador
        miss_1_enemy = GameObject.FindGameObjectsWithTag("miss_1_enemy");//sonido errar disparo enemigo
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
        StartCoroutine(_GamehandlerRED.Mensaje_bardeadaJugadorErrarDisparo());//bardeo erro disparo
        miss_audio_jugador[Random.Range(0,miss_audio_jugador.Length)].GetComponent<AudioSource>().Play();//activo sonido errar disparo
        
        mymesh.enabled = false;//desactivo esta cuadricula
        miCollyder.enabled = false;//desactivo la colision de esta cuadricula
        DeshabilitarCuadriculaPhoton();//desactivar cuadricula enemigo parte superior

        _GamehandlerRED.SetPuedoPresionarBoton(false);//no puedo volver a presionar los botones
        yield return new WaitForSeconds(0.4f);
        _GamehandlerRED.IsTurnoEnemigo();//es turno de enemigo
    }

     /// <summary>Desactivo o activa todo lo relacionado a la cuadricula superior. Si uso otros tendría que deshabilitarse la cuadricula superior del otro</summary>
    private void DeshabilitarCuadriculaPhoton()
    {
        photonView.RPC("DeshabilitarCuadriculaEnemigoSuperior", //Nombre de la función que es llamada localmente
                RpcTarget.OthersBuffered,//para llamar a la función en Otros
                false//saca la parte del tablero que corresponde a esta cuadricula
            ); 
    }

     /// <summary>Para desactivar cuadricula usando Photon</summary>
    [PunRPC]
    public void DeshabilitarCuadriculaEnemigoSuperior(bool deshabilitarCuadricula)
    {
        StartCoroutine(_GamehandlerRED.Mensaje_bardeadaEnemigoErrarDisparo());//bardeada enemigo erro disparo
        miss_1_enemy[Random.Range(0,miss_1_enemy.Length)].GetComponent<AudioSource>().Play();//activo sonido errar disparo pero solo lo escucha el enemigo
        CuadriculaEnemigoSuperior.enabled = deshabilitarCuadricula;//deshabilito cuadricula pero solo lo hace el enemigo
    }
    

    //estoy usando la interface por eso llamo a esto obligatoriamente
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}
