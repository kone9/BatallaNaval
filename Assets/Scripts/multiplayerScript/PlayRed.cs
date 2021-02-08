using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Photon.Pun;


public class PlayRed : MonoBehaviourPunCallbacks , Photon.Pun.IPunObservable
{   
    GameHandlerAcomodarPIezas _GameHandlerAcomodarPIezas;
    public GameObject pantallaEsperaRival;
    private PhotonView photonMostrar;
    private DatosGlobalesRed _DatosGlobalesRed;

    private void Awake() 
    {
        _GameHandlerAcomodarPIezas = FindObjectOfType<GameHandlerAcomodarPIezas>();
        photonMostrar = GetComponent<PhotonView>();
        _DatosGlobalesRed = FindObjectOfType<DatosGlobalesRed>();
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
        if(_DatosGlobalesRed.GetPlayerListoRed() && _DatosGlobalesRed.GetEnemyListoRed())//si el player esta listo y si el enemigo esta
            {
                print("cambia al Nivel de juego");
                SceneManager.LoadScene("JugarContraEnemigoEnRed");    
            }
    }


    /// <summary>Al presionar el boton verifico si soy yo o si es el otro jugador</summary>
    public void PreparadoParaIniciarEnRed()
    {
        pantallaEsperaRival.SetActive(true);

        // _DatosGlobalesRed.SetRivalListoRed(true);
        // _DatosGlobalesRed.SettPlayerAndEnemyListoRed();
        photonView.RPC("EmpezarNivel",RpcTarget.All);

        _GameHandlerAcomodarPIezas.GuardarPosicionBarcos();
        _GameHandlerAcomodarPIezas.GuardarRotacionesBarcos();
    }


    [PunRPC]
    public void EmpezarNivel()
    {
        _DatosGlobalesRed.SettPlayerAndEnemyListoRed();
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
