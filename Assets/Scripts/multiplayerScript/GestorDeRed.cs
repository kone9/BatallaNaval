using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//importante para usar photon.
using Photon.Pun;
using Photon.Realtime;

public class GestorDeRed : MonoBehaviourPunCallbacks 
{
    public static Action OnPlayersConnected = delegate { };

    public Text info;

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
        info.text = "Felicidades estoy conectado\n al servidor maestro";
    }

    //al unirse al servidor crea un cuarto
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        PhotonNetwork.JoinOrCreateRoom("Cuarta", new RoomOptions{MaxPlayers = 4}, TypedLobby.Default );
    }

    public override void OnCreatedRoom()
    {
        print("cuarto creado");
        info.text = "cuarto creado";
    }

    
    public override void OnJoinedRoom()//cuando nos unamos al cuerto podemos instanciar jugadores o hacer cualquier cosa con los GameObjects
    {
        print("Este jugador se unido al cuerto");
        info.text = "Este jugador se unio al cuerto";

        //desde aqui puedo isntanciar cosas al iniciar el nivel usar la carpeta resources de photon
        Vector3 posicion = new Vector3(0,4,0);
        // PhotonNetwork.Instantiate("Personaje",posicion,Quaternion.identity,0);
        if (PhotonNetwork.PlayerList.Length == 2)
            OnPlayersConnected();
    }

	public override void OnPlayerEnteredRoom(Player newPlayer)
	{
		base.OnPlayerEnteredRoom(newPlayer);
        if (PhotonNetwork.PlayerList.Length == 2)
            OnPlayersConnected();
    }

	// Update is called once per frame
	void Update()
    {
    }
}
