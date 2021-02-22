using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    public Button Multiplayer;
    public Button Singleplayer;
    
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
        SceneManager.LoadScene("AcomodarPiezas");
    }

    public void IniciarMultiplayer()
    {
         SceneManager.LoadScene("AcomodarPiezasEnRed");
    }

}
