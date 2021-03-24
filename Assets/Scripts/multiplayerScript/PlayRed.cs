using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using Photon.Pun;



public class PlayRed : MonoBehaviourPunCallbacks , Photon.Pun.IPunObservable
{   
    GameHandlerAcomodarPIezas _GameHandlerAcomodarPIezas;
    public GameObject pantallaEsperaRival;
    private PhotonView photonMostrar;

    public Toggle soyJugadorToggle;
    public Toggle soyEnemigoToggle;

    public Toggle ListoJugadorRedToglle;
    public Toggle ListoEnemigoRedToglle;

    public int tiempoAntesDeCambiarEscena = 5;
   

    private bool listoPlayerRED = false;

    private bool listoEnemigoRED = false;


    private void Awake() 
    {
        _GameHandlerAcomodarPIezas = FindObjectOfType<GameHandlerAcomodarPIezas>();
        photonMostrar = GetComponent<PhotonView>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        listoPlayerRED = false;
        listoEnemigoRED = false;
        ListoJugadorRedToglle.isOn = listoPlayerRED;
        ListoEnemigoRedToglle.isOn = listoEnemigoRED;
    }
    

    // Update is called once per frame
    void Update()
    {
        // VerificarEnemigosEnRed();//para verificar constantemente el valor del enemigo.

        if(listoPlayerRED && listoEnemigoRED)//si el player esta listo y si el enemigo esta
        {
            Invoke("CambiarDeEscena",tiempoAntesDeCambiarEscena);
        }    
    }


    void CambiarDeEscena()
    {
        print("cambia al Nivel de juego");
        SceneManager.LoadScene("JugarContraEnemigoEnRed");    
    }


    /// <summary>Al presionar el boton verifico si soy yo o si es el otro jugador</summary>
    public void PreparadoParaIniciarEnRed()
    {
        pantallaEsperaRival.SetActive(true);
        
        //para probar luego borrar
        // listoPlayerRED = true;
        // listoEnemigoRED = true;

        //para avisar cuando el player esta listo
        photonView.RPC("EmpezarNivel",RpcTarget.All,photonView.IsMine);
        
        _GameHandlerAcomodarPIezas.GuardarPosicionBarcos();
        _GameHandlerAcomodarPIezas.GuardarRotacionesBarcos();
  
    }

    [PunRPC]
    public void EmpezarNivel(bool isMine)
    {
        if(isMine)//si soy jugador "YO"
        { 
            listoPlayerRED = true;
            
            ListoJugadorRedToglle.isOn = listoPlayerRED;
            ListoEnemigoRedToglle.isOn = listoEnemigoRED;
        }
        if(!isMine)//si soy enemigo " NO YO "
        {
            listoEnemigoRED = true;
            ListoJugadorRedToglle.isOn = listoPlayerRED;
            ListoEnemigoRedToglle.isOn = listoEnemigoRED;
        }
    }


    //para sincronizar variables entre jugadores esto es util para la vida entre otras cosas
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)//si estoy escribiendo datos...Siempre soy yo el que escribre datos
        {
            // stream.SendNext(listoPlayerRed);
            // stream.SendNext(listoEnemigoRed);
            stream.SendNext(listoPlayerRED);
            stream.SendNext(listoEnemigoRED);
        }
        else //si esta escribiendo datos un avatar
        {
            // listoPlayerRed =(bool) stream.ReceiveNext();
            // listoEnemigoRed = (bool)stream.ReceiveNext();
            listoPlayerRED = (bool)stream.ReceiveNext();
            listoEnemigoRED = (bool)stream.ReceiveNext();
        }
    }
    

}
