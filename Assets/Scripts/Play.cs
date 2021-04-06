using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Play : MonoBehaviour
{
    public GameObject imagenEsperandoEnemigo;

    private BotonAuto _botonAuto;
    GameHandlerAcomodarPIezas _GameHandlerAcomodarPIezas;

    GameObject musicaInicio;
    AudioSource PuertaSonido;
    AudioSource efectoBoton_3;
    AudioSource efectoBoton_2;
    private GameObject _HandlerDificultadEntreNiveles;//para referencia a la dificultad entre niveles
    private GameObject _DatosGlobales;

    private void Awake() {
        _GameHandlerAcomodarPIezas = FindObjectOfType<GameHandlerAcomodarPIezas>();
        musicaInicio = GameObject.Find("musicaInicio");
        efectoBoton_3 = GameObject.Find("efectoBoton_3").GetComponent<AudioSource>();
        efectoBoton_2 = GameObject.Find("efectoBoton_2").GetComponent<AudioSource>();
        _HandlerDificultadEntreNiveles = GameObject.Find("HandlerDificultadEntreNiveles");//para obtener la referencía al script
        _DatosGlobales = GameObject.Find("DatosGlobales");
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
        //activo sonido de boton
        efectoBoton_3.Play();

        //guardo las posiciones de los barcos del jugador
        _GameHandlerAcomodarPIezas.GuardarPosicionBarcos();
        _GameHandlerAcomodarPIezas.GuardarRotacionesBarcos();

        //destruyo la musica inicio
        Destroy(musicaInicio);

        //SACO ESTO POR UN MINUTO VOLVER A COLOCARLO LUEGO DE VERIFICARLOS NIVELES
        //coloco cartel esperando enemigo
        // imagenEsperandoEnemigo.SetActive(true);
        // yield return new WaitForSeconds(2);
        //Presiono boton automatico para volver a acomodar y luego guardo las posiciones 
        // StartCoroutine(_botonAuto.PosicionarBarcoAleatoriamente());//vuelvo a posicionar los barcos
        yield return new WaitForSeconds(1);

        _GameHandlerAcomodarPIezas.GuardarPosicionBarcosEnemigos();//guardo sus posiciones
        _GameHandlerAcomodarPIezas.GuardarRotacionesBarcosEnemigo();//guardo sus posiciones
        SceneManager.LoadScene("JugarContraEnemigo");
    }



    /// <summary>Vuelve a la escena de Inicio</summary>
    public void Volver()
    {
        Destroy(_HandlerDificultadEntreNiveles);//destruyo el _handler entre niveles que maneja dificultad y nivel actual
        Destroy(_DatosGlobales);//destruyo los datos globales
        SceneManager.LoadScene("MenuInicio");//cambio a menu de inicio
    }

    

}
