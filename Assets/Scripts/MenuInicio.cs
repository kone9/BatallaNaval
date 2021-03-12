using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    public Button Multiplayer;
    public Button Singleplayer;

    AudioSource efectoBoton_1;
    AudioSource efectoBoton_3;

    private void Awake() {
        efectoBoton_1 = GameObject.Find("efectoBoton_1").GetComponent<AudioSource>();
        efectoBoton_3 = GameObject.Find("efectoBoton_3").GetComponent<AudioSource>();
    }    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IniciarSinglePlayer()
    {
        efectoBoton_1.Play();
        SceneManager.LoadScene("AcomodarPiezas");
    }

    public void IniciarMultiplayer()
    {
        efectoBoton_3.Play();
        SceneManager.LoadScene("AcomodarPiezasEnRed");
    }

}
