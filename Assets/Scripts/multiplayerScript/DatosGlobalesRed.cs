using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public class DatosGlobalesRed : MonoBehaviourPunCallbacks,IPunObservable
{

    public static DatosGlobalesRed instanciaGlobalScript;
    DatosGlobales _DatosGlobales;

    GameHandlerAcomodarPIezas _GameHandlerAcomodarPIezas;

    public Vector3[] posicionesBarcoRivalRed = new Vector3[5];

    public bool listoEnemigoRed = false;
    public bool listoPlayerRed = false;

    private void Awake()
    {
        _DatosGlobales = FindObjectOfType<DatosGlobales>();
        _GameHandlerAcomodarPIezas = FindObjectOfType<GameHandlerAcomodarPIezas>();
    }


    // Start is called before the first frame update
    void Start()
    {
        if (DatosGlobalesRed.instanciaGlobalScript == null)
        {
            DatosGlobalesRed.instanciaGlobalScript =  this;
            DontDestroyOnLoad(this.gameObject);//este GameObject nunca se destruye
        }
        else
        {
            Destroy(this.gameObject);//este GameObject nunca se destruye
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }

    /// <summary>Devuelve un arreglo de las rotaciónes de los barcos en quaternions</summary>
    public Vector3[] GetPosicionBarcosRivalRed()
    {
        if(!photonView.IsMine)//sino soy yo..
        {
            posicionesBarcoRivalRed =  _DatosGlobales.GetPosicionesBarcos();
        }

        return posicionesBarcoRivalRed;
    }


    public bool GetEnemyListoRed()
    {
        bool listo = false;
        // if(!photonView.IsMine)//sino soy yo
        // {
        listo = listoEnemigoRed ;
        // }
        return listo;
    }

    public bool GetPlayerListoRed()
    {
        bool listo = false;
        listo = listoPlayerRed;
        return listo;
    }

    [PunRPC]
    public void SetEnemyListoRed(bool listo)
    {
        if(!photonView.IsMine)
        {
            listoEnemigoRed = listo;
        }
    }

    
    public void SettPlayerListoRed(bool listo)
    {
        listoPlayerRed = listo;
    }

    
    public void SettPlayerAndEnemyListoRed()
    {
        
        // if(!photonView.IsMine)//si soy yo
        // {
            print("soy yo tendria que activar yo");
            listoPlayerRed = true;//si soy yo
        // }

        // if(photonView.IsMine)//sino soy yo
        // {
            //print("no soy yo se tendria que activar el enemigo");
            listoEnemigoRed = true;
        // }
    }



    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
         if(stream.IsWriting)//si estoy escribiendo datos...Siempre soy yo el que escribre datos
        {
            // stream.SendNext(_GameHandlerAcomodarPIezas.GetEnemigoListo());
            stream.SendNext(listoEnemigoRed);
            stream.SendNext(listoPlayerRed);
        }
        else //si esta escribiendo datos un avatar
        {
            // _GameHandlerAcomodarPIezas.SetEnemigoListo((bool)stream.ReceiveNext());
            listoEnemigoRed = (bool)stream.ReceiveNext();
            listoPlayerRed =(bool) stream.ReceiveNext();
            // _GameHandlerAcomodarPIezas.SetPlayerListo((bool)stream.ReceiveNext());
        }
    }
}
