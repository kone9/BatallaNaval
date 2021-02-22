using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Play : MonoBehaviour
{
    GameHandlerAcomodarPIezas _GameHandlerAcomodarPIezas;

    private void Awake() {
        _GameHandlerAcomodarPIezas = FindObjectOfType<GameHandlerAcomodarPIezas>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>Cambia a la escena principal de juego</summary>
    /// <param>@None </param>
    public void CambiarDeEscena()//Script para cambiar a la escena principal
    {
        
        SceneManager.LoadScene("JugarContraEnemigo");
        _GameHandlerAcomodarPIezas.GuardarPosicionBarcos();
        _GameHandlerAcomodarPIezas.GuardarRotacionesBarcos();  
    }

    /// <summary>Vuelve a la escena de Inicio</summary>
    public void Volver()
    {
        SceneManager.LoadScene("AcomodarPiezas");
    }

    

}
