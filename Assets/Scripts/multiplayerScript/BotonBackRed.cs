using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Photon.Pun;

public class BotonBackRed : MonoBehaviour,IPunObservable
{
    public GameObject Ui_EnemyDisconect;
    GameHandlerRED _GameHandlerRED;
    GameObject _GestorDeRed;
    PhotonView _PhotonView;
    AudioSource SonidoWinner;

    private void Awake()
    {
        _GestorDeRed = GameObject.Find("GestorDeRed");
        _PhotonView = GetComponent<PhotonView>();
        SonidoWinner = GameObject.Find("SonidoWinner").GetComponent<AudioSource>();
        _GameHandlerRED = FindObjectOfType<GameHandlerRED>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VolverYDesconectarDeRed()
    {
        
        PhotonNetwork.Disconnect();//desconecto del sirvidor
        Destroy(_GestorDeRed);//destruyo el gestor de Red

        SceneManager.LoadScene("MenuInicio");//reinicio a menu de inicio
    }

    public void Volver_Desconectar_Y_Avisar_Enemigo()
    {
        StartCoroutine("DesconectarPhoton");
    }

    /// <summary>Desconecto todo lo relacionado a photon y aviso a rival, espero 1 segundo antes de desconectar</summary>
    IEnumerator DesconectarPhoton()
    {
        //photon para desirle al que esta del otro lado
        _PhotonView.RPC("PlayerDisconect",
            RpcTarget.OthersBuffered
        );
        yield return new WaitForSeconds(0.5f);
        PhotonNetwork.Disconnect();//desconecto del sirvidor
        Destroy(_GestorDeRed);//destruyo el gestor de Red

        SceneManager.LoadScene("MenuInicio");//reinicio a menu de inicio
    }

    /// <summary>Hace que muestre la pantalla enemigo Desconectado</summary>
    [PunRPC]
    void PlayerDisconect()
    {
        print("el rival volvio al menu de inicio, aparece pantalla enemyDisconect");
        _GameHandlerRED.SetPuedoPresionarBoton(false);//no puedo presionar boton
        SonidoWinner.Play();
        Ui_EnemyDisconect.SetActive(true);//activo el enemigo
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
    }
}
