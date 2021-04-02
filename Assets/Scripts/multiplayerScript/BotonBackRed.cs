using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Photon.Pun;

public class BotonBackRed : MonoBehaviour
{
    GameObject _GestorDeRed;
    private void Awake()
    {
        _GestorDeRed = GameObject.Find("GestorDeRed");
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

    
}
