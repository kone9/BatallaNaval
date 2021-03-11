using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Play : MonoBehaviour
{
    public GameObject imagenEsperandoEnemigo;

    private BotonAuto _botonAuto;
    GameHandlerAcomodarPIezas _GameHandlerAcomodarPIezas;

    private void Awake() {
        _GameHandlerAcomodarPIezas = FindObjectOfType<GameHandlerAcomodarPIezas>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _botonAuto = FindObjectOfType<BotonAuto>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>Cambia a la escena principal de juego con el boton</summary>
    public void CambiarDeEscena()//Script para cambiar a la escena principal
    {
        
        StartCoroutine("acomodarBarcosParaCambiarDeNivel");  
    }


    /// <summary>Cosas que hago antes de cambiar de escena uso corrutina</summary>
    IEnumerator acomodarBarcosParaCambiarDeNivel()
    {
        //guardo las posiciones de los barcos del jugador
        _GameHandlerAcomodarPIezas.GuardarPosicionBarcos();
        _GameHandlerAcomodarPIezas.GuardarRotacionesBarcos();

        //coloco cartel esperando enemigo
        imagenEsperandoEnemigo.SetActive(true);
        yield return new WaitForSeconds(2);
        //Presiono boton automatico para volver a acomodar y luego guardo las posiciones 
        StartCoroutine(_botonAuto.PosicionarBarcoAleatoriamente());
        _GameHandlerAcomodarPIezas.GuardarPosicionBarcosEnemigos();
        _GameHandlerAcomodarPIezas.GuardarRotacionesBarcosEnemigo();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("JugarContraEnemigo");
    }



    /// <summary>Vuelve a la escena de Inicio</summary>
    public void Volver()
    {
        SceneManager.LoadScene("MenuInicio");
    }

    

}
