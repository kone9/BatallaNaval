using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamehandler : MonoBehaviour
{
    DatosGlobales _DatosGlobales;
    GameObject[] barcos;
    GameObject[] barcosGrilla;

    public int cantidadDeAciertosJugador = 0;

    EnemigoHandler _EnemigoHandler;

    public GameObject fondoTablero;

    private bool puedoPresionarBoton = true;

    public Animator animacionLuzDecoradoRoja;

    /////////////////////////////////////////////////////////
    //referencia a todos los barcos de la escena del ENEMIGO
    private GameObject barco_1_enemigo;
    private GameObject barco_2_enemigo;
    private GameObject barco_3_enemigo;
    private GameObject portaAviones_enemigo;
    private GameObject Submarino_enemigo;

     //referencia a todos los barcos de la escena del JUGADOR
    private GameObject barco_1_jugador;
    private GameObject barco_2_jugador;
    private GameObject barco_3_jugador;
    private GameObject PortaAviones_jugador;
    private GameObject submarino_jugador;
/////////////////////////////////////////////////////////
    //referencia a todos las posiciones y rotaciones de barcos de la escena del ENEMIGO
    private Vector3 enemigo_barco_1_Posicion;
    private Vector3 enemigo_barco_2_Posicion;
    private Vector3 enemigo_barco_3_Posicion;
    private Vector3 enemigo_PortaAviones_Posicion;
    private Vector3 enemigo_submarino_Posicion;

    private Quaternion enemigo_barco_1_Rotacion;
    private Quaternion enemigo_barco_2_Rotacion;
    private Quaternion enemigo_barco_3_Rotacion;
    private Quaternion enemigo_PortaAviones_Rotacion;
    private Quaternion enemigo_submarino_Rotacion;

    //para saber si puedo o no puedo presionar un boton de la grilla,
    // se usa para ver que no se acerto el disparo o si y para un delay
    // por el tema de sonido
   
    ///////////////////////////////////////////////////
    //relacioando a GameOver
    public GameObject UI_GameOver;
    public GameObject UI_Winner;

    //TEST PARA SUBIR A RAMA ARIEL

//////////////////////////////////////////////////////    

    private void Awake() {
       
        _DatosGlobales = FindObjectOfType<DatosGlobales>();
        _EnemigoHandler = FindObjectOfType<EnemigoHandler>();
        barcos = GameObject.FindGameObjectsWithTag("boat");
        barcosGrilla = GameObject.FindGameObjectsWithTag("barcosGrilla");
        buscarBarcos();
    }

    
    void buscarBarcos()
    {
        //barcos de la grilla cuadro de abajo
        barco_1_enemigo = GameObject.Find("barco_1_enemigo");
        barco_2_enemigo = GameObject.Find("barco_2_enemigo");
        barco_3_enemigo = GameObject.Find("barco_3_enemigo");
        portaAviones_enemigo = GameObject.Find("PortaAviones_enemigo");
        Submarino_enemigo  = GameObject.Find("submarino_enemigo");
        //barcos del jugador cuadro de arriba
        barco_1_jugador = GameObject.Find("barco_1");
        barco_2_jugador = GameObject.Find("barco_2");
        barco_3_jugador = GameObject.Find("barco_3");
        PortaAviones_jugador = GameObject.Find("portaAviones");
        submarino_jugador = GameObject.Find("submarino");
    }


    // Start is called before the first frame update
    void Start()
    {
       AcomodarLosBarcos();
       AcomodarLosBarcosGrillaEnemigo();
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }


    /// <summary>Acomoda los barcos del JUGADOR según la posicion del nivel acomodar piezas</summary>
    private void AcomodarLosBarcos()
    {
        Vector3 Posicion_barco_1 = _DatosGlobales.Posicion_barco_1;
        Vector3 Posicion_barco_2 = _DatosGlobales.Posicion_barco_2;
        Vector3 Posicion_barco_3 = _DatosGlobales.Posicion_barco_3;
        Vector3 Posicion_portaAviones = _DatosGlobales.Posicion_portaAviones;
        Vector3 Posicion_Submarino = _DatosGlobales.Posicion_Submarino;

        Quaternion rotacion_barco_1 = _DatosGlobales.rotacion_barco_1;
        Quaternion rotacion_barco_2 = _DatosGlobales.rotacion_barco_2;
        Quaternion rotacion_barco_3 = _DatosGlobales.rotacion_barco_3;
        Quaternion rotacion_portaAviones = _DatosGlobales.rotacion_portaAviones;
        Quaternion rotacion_submarino = _DatosGlobales.rotacion_Submarino;



        Posicion_barco_1.z += 250;
        Posicion_barco_2.z += 250;
        Posicion_barco_3.z += 250;
        Posicion_portaAviones.z += 250;
        Posicion_Submarino.z += 250;

        //posiciones
        barco_1_jugador.transform.position = Posicion_barco_1;
        barco_2_jugador.transform.position = Posicion_barco_2;
        barco_3_jugador.transform.position = Posicion_barco_3;
        PortaAviones_jugador.transform.position = Posicion_portaAviones;
        submarino_jugador.transform.position = Posicion_Submarino;

        //rotaciones
        barco_1_jugador.transform.rotation = rotacion_barco_1;
        barco_2_jugador.transform.rotation = rotacion_barco_2;
        barco_3_jugador.transform.rotation = rotacion_barco_3;
        PortaAviones_jugador.transform.rotation = rotacion_portaAviones;
        submarino_jugador.transform.rotation = rotacion_submarino;
    }

    /// <summary>Acomoda los barcos del ENEMIGO según la posicion del nivel acomodar piezas</summary>
    private void AcomodarLosBarcosGrillaEnemigo()
    {
        Vector3 Posicion_barco_1 = _DatosGlobales.Posicion_barco_1_enemigo;
        Vector3 Posicion_barco_2 = _DatosGlobales.Posicion_barco_2_enemigo;
        Vector3 Posicion_barco_3 = _DatosGlobales.Posicion_barco_3_enemigo;
        Vector3 Posicion_portaAviones = _DatosGlobales.Posicion_portaAviones_enemigo;
        Vector3 Posicion_Submarino = _DatosGlobales.Posicion_Submarino_enemigo;

        Quaternion rotacion_barco_1 = _DatosGlobales.rotacion_barco_1_enemigo;
        Quaternion rotacion_barco_2 = _DatosGlobales.rotacion_barco_2_enemigo;
        Quaternion rotacion_barco_3 = _DatosGlobales.rotacion_barco_3_enemigo;
        Quaternion rotacion_portaAviones = _DatosGlobales.rotacion_portaAviones_enemigo;
        Quaternion rotacion_submarino = _DatosGlobales.rotacion_Submarino_enemigo;


        //posiciones
        barco_1_enemigo.transform.position = Posicion_barco_1;
        barco_2_enemigo.transform.position = Posicion_barco_2;
        barco_3_enemigo.transform.position = Posicion_barco_3;
        portaAviones_enemigo.transform.position = Posicion_portaAviones;
        Submarino_enemigo.transform.position = Posicion_Submarino;

        //rotaciones
        barco_1_enemigo.transform.rotation = rotacion_barco_1;
        barco_2_enemigo.transform.rotation = rotacion_barco_2;
        barco_3_enemigo.transform.rotation = rotacion_barco_3;
        portaAviones_enemigo.transform.rotation = rotacion_portaAviones;
        Submarino_enemigo.transform.rotation = rotacion_submarino;
    }

    /// <summary>Si es turno del jugador no activa el fondo de grilla<</summary>
    public void IsTurnoJugador()
    {
        animacionLuzDecoradoRoja.SetBool("isTurnEnemy",false);
        fondoTablero.SetActive(false);
        puedoPresionarBoton = true;
    }

    /// <summary>Si es turno del enemigo activa el fondo de grilla</summary>
    public void IsTurnoEnemigo()
    {
        fondoTablero.SetActive(true);
        puedoPresionarBoton = false;
        animacionLuzDecoradoRoja.SetBool("isTurnEnemy",true);
        _EnemigoHandler.DispararFuegoEnemigoHastaErrar();
    }

    /// <summary>Si puedo o no puedo presionar boton</summary>
    public void SetPuedoPresionarBoton(bool presioneBoton)
    {
        puedoPresionarBoton = presioneBoton;
    }

    /// <summary>Retorna un bolean "si puedo o no puedo" presionar Boton</summary>
    public bool GetPuedoPresionarBoton()
    {
        return this.puedoPresionarBoton;
    }

    /// <summary>Cambia al nivel GameOverWinner</summary>
    public void GameOverWinner()
    {
        fondoTablero.SetActive(false);//hago que el tablero no se vea
        SetPuedoPresionarBoton(false);//no puedo presionar botones
        UI_Winner.SetActive(true);
    }

    /// <summary>Cambia al nivel GameOverLose</summary>
    public void GameOverLose()
    {
        SetPuedoPresionarBoton(false);//no puedo presionar botones
        UI_GameOver.SetActive(true);
    }

}
