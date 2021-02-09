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
    private DatosGlobalesRed _DatosGlobalesRed;

    public Toggle soyJugadorToggle;
    public Toggle soyEnemigoToggle;

    public Toggle ListoJugadorRedToglle;
    public Toggle ListoEnemigoRedToglle;
   

    [SerializeField]
    private bool SoyJugador = false;
    
    [SerializeField]
    private bool SoyEnemigo = false;
    
    public bool listoPlayerRed = false;

    public bool listoEnemigoRed = false;



    private void Awake() 
    {
        _GameHandlerAcomodarPIezas = FindObjectOfType<GameHandlerAcomodarPIezas>();
        photonMostrar = GetComponent<PhotonView>();
        _DatosGlobalesRed = FindObjectOfType<DatosGlobalesRed>();
    }

    // Start is called before the first frame update
    void Start()
    {
        listoEnemigoRed = false;
        listoPlayerRed = false;
        ListoJugadorRedToglle.isOn = listoPlayerRed;
        ListoEnemigoRedToglle.isOn = listoEnemigoRed;
        StartCoroutine("SoyjugadorOenemigo");
        
    }


    IEnumerator SoyjugadorOenemigo()
    {
        while(true)
        {
            SoyJugador = _DatosGlobalesRed.SoyJugador;
            SoyEnemigo = _DatosGlobalesRed.SoyEnemigo;
            soyJugadorToggle.isOn =  _DatosGlobalesRed.SoyJugador;
            soyEnemigoToggle.isOn =  _DatosGlobalesRed.SoyEnemigo;
            yield return new WaitForSeconds(0.1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(listoPlayerRed && listoEnemigoRed)//si el player esta listo y si el enemigo esta
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
        // EmpezarNivel();
        _GameHandlerAcomodarPIezas.GuardarPosicionBarcos();
        _GameHandlerAcomodarPIezas.GuardarRotacionesBarcos();
    }



    [PunRPC]
    public void EmpezarNivel()
    {
        if(_DatosGlobalesRed.SoyJugador == true)
        {
            listoPlayerRed = true;
            SoyEnemigo = false;
            ListoJugadorRedToglle.isOn = listoPlayerRed;
            ListoEnemigoRedToglle.isOn = listoEnemigoRed;
        }
        if(_DatosGlobalesRed.SoyEnemigo == true)
        {
            listoEnemigoRed = true;
            SoyJugador = false;
            ListoJugadorRedToglle.isOn = listoPlayerRed;
            ListoEnemigoRedToglle.isOn = listoEnemigoRed;
        }
    }


    //para sincronizar variables entre jugadores esto es util para la vida entre otras cosas
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)//si estoy escribiendo datos...Siempre soy yo el que escribre datos
        {
            stream.SendNext(listoPlayerRed);
            stream.SendNext(listoEnemigoRed);
        }
        else //si esta escribiendo datos un avatar
        {
            listoPlayerRed =(bool) stream.ReceiveNext();
            listoEnemigoRed = (bool)stream.ReceiveNext();
        }
    }
    

}
