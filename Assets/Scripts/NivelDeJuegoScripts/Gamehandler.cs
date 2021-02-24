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
    //referencia a todos los barcos de la escena del JUGADOR
    private GameObject barco_1;
    private GameObject barco_2;
    private GameObject barco_3;
    private GameObject portaAviones;
    private GameObject Submarino;
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
        barco_1 = GameObject.Find("barco_1");
        barco_2 = GameObject.Find("barco_2");
        barco_3 = GameObject.Find("barco_3");
        portaAviones = GameObject.Find("PortaAviones");
        Submarino  = GameObject.Find("submarino");
        //barcos del jugador cuadro de arriba
        barco_1_jugador = GameObject.Find("barco_1_jugador");
        barco_2_jugador = GameObject.Find("barco_2_jugador");
        barco_3_jugador = GameObject.Find("barco_3_jugador");
        PortaAviones_jugador = GameObject.Find("PortaAviones_jugador");
        submarino_jugador = GameObject.Find("submarino_jugador");
    }


    // Start is called before the first frame update
    void Start()
    {
       AcomodarLosBarcos();
       AcomodarLosBarcosGrilla();
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }


    //acomoda los barcos que estan en la pantalla de arriba,osea los del jugador
    private void AcomodarLosBarcos()
    {
        // int indice = 0;
        // foreach (GameObject i in barcos)
        // {
        //     //acomodar posición
        //     i.transform.position = new Vector3(
        //             _DatosGlobales.GetPosicionesBarcos()[indice].x,
        //             _DatosGlobales.GetPosicionesBarcos()[indice].y,
        //             _DatosGlobales.GetPosicionesBarcos()[indice].z + 250
        //     );
        //     //acomodar rotación
        //     i.transform.rotation = _DatosGlobales.GetRotacionBarcos()[indice];
        //     indice += 1;
        // }
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

    //estotendria que hacer mediante una aleatoriedad ya que son los barcos del enemigo
    // y como es la maquina con hacer esto aleatorio seria suficiente
    private void AcomodarLosBarcosGrilla()
    {
        // int indice = 0;
        // foreach (GameObject i in barcosGrilla)
        // {
        //     //acomodar posición
        //     i.transform.position = _DatosGlobales.GetPosicionesBarcos()[indice];
        //     //acomodar rotación
        //     i.transform.rotation = _DatosGlobales.GetRotacionBarcos()[indice];
        //     indice += 1;
        // }

        //asi tendria que obtener las posiciones del los barcos del enemigo
        //posiciones
            // barco_1.transform.position = enemigo_barco_1_posicion;
            // barco_2.transform.position = enemigo_barco_2_posicion;
            // barco_3.transform.position = enemigo_barco_3_posicion;
            // portaAviones.transform.position = enemigo_portaAviones_posicion;
            // Submarino.transform.position = enemigoPosicionSubmarino;
        //rotaciones
            // barco_1.transform.rotation = enemigo_barco_1_Rotacion;
            // barco_2.transform.rotation = enemigo_barco_2_rotacion;
            // barco_3.transform.rotation = enemigo_barco_3_rotacion;
            // portaAviones.transform.rotation = enemigo_portaAviones_rotacion;
            // Submarino.transform.rotation = enemigo_Submarino_rotacion;
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

    /// <summary>Retorna un bolean "si puedo o no puedo" presionar Boton</summary>
    public bool GetPuedoPresionarBoton()
    {
        return this.puedoPresionarBoton;
    }

    /// <summary>Cambia al nivel GameOverWinner</summary>
    public void GameOverWinner()
    {
        SceneManager.LoadScene("YouWinner");
    }

    /// <summary>Cambia al nivel GameOverLose</summary>
    public void GameOverLose()
    {
        SceneManager.LoadScene("Youlose");
    }

}
