using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//importante para usar photon.
using Photon.Pun;
using Photon.Realtime;

public class GestorDeRed : MonoBehaviourPunCallbacks
{
    
    public static GestorDeRed instanciaRed;//para isntanciar la red PHOTON y conectarme al servidor

    private void Awake()
    {
        //Esto evita que se destruya  el game object que maneja la red
        if(instanciaRed == null)
        {
            instanciaRed = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }    
    }


    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();//Crea 2 eventos on "OnConnectedToMaster" y "OnJoinedLobby"
    }

    //Cuando se conecta al servidor maestro
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        print("Felicidades estoy conectado al servidor maestro");
    }

    //al unirse al servidor crea un cuarto
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        PhotonNetwork.CreateRoom("Cuarta", new RoomOptions{MaxPlayers = 4}, TypedLobby.Default );
    }

    public override void OnJoinedRoom()//cuando nos unamos al cuerto podemos instanciar jugadores o hacer cualquier cosa con los GameObjects
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
