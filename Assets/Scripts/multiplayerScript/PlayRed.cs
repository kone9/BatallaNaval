using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Photon.Pun;
using Photon.Realtime;
using Photon.Utilities;


public class PlayRed : MonoBehaviourPunCallbacks , Photon.Pun.IPunObservable
{   
    GameHandlerAcomodarPIezas _GameHandlerAcomodarPIezas;
    public GameObject pantallaEsperaRival;
    private PhotonView photonMostrar;

    private void Awake() 
    {
        _GameHandlerAcomodarPIezas = FindObjectOfType<GameHandlerAcomodarPIezas>();
        photonMostrar = GetComponent<PhotonView>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // if(!photonView.IsMine)//sino soy yo
        // {
        //     Destroy(this);
        // }
    }


    // Update is called once per frame
    void Update()
    {
        if(_GameHandlerAcomodarPIezas.GetPlayerListo() && _GameHandlerAcomodarPIezas.GetEnemigoListo())//si el player esta listo y si el enemigo esta
            {
                print("cambia al Nivel de juego");
                SceneManager.LoadScene("JugarContraEnemigoEnRed");    
            }
    }


    /// <summary>Al presionar el boton verifico si soy yo o si es el otro jugador</summary>
    public void PreparadoParaIniciarEnRed()
    {
        // if(photonMostrar.IsMine)//si soy yo el que presione el boton
        // {
        pantallaEsperaRival.SetActive(true);
        _GameHandlerAcomodarPIezas.SetPlayerListo(true);
        _GameHandlerAcomodarPIezas.GuardarPosicionBarcos();
        _GameHandlerAcomodarPIezas.GuardarRotacionesBarcos();
        // }

        // if(!photonMostrar.IsMine)//sino soy yo el que presione el boton
        // {
        //      pantallaEsperaRival.SetActive(true);
        //     // _GameHandlerAcomodarPIezas.SetPlayerListo(true);
        //     _GameHandlerAcomodarPIezas.GuardarPosicionBarcos();
        //     _GameHandlerAcomodarPIezas.GuardarRotacionesBarcos();
        //     _GameHandlerAcomodarPIezas.SetEnemigoListo(true);
        // }
    }

    //para sincronizar variables entre jugadores esto es util para la vida entre otras cosas
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)//si estoy escribiendo datos...Siempre soy yo el que escribre datos
        {
            // stream.SendNext(_GameHandlerAcomodarPIezas.GetEnemigoListo());
            stream.SendNext(_GameHandlerAcomodarPIezas.GetPlayerListo());
        }
        else //si esta escribiendo datos un avatar
        {
            // _GameHandlerAcomodarPIezas.SetEnemigoListo((bool)stream.ReceiveNext());
            _GameHandlerAcomodarPIezas.SetPlayerListo((bool)stream.ReceiveNext());
        }
    }
    

}
