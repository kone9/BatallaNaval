using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosGlobales : MonoBehaviour
{

    public static DatosGlobales instanciaGlobalScript;
    public GameObject[] barcosDeLaEscena = new GameObject[5];
    public Vector3[] posicionesBarcos = new Vector3[5];

    public Quaternion[] rotacionesBarcos = new Quaternion[5];

    public Vector3[] posicionesBarcos_enemigo = new Vector3[5];
    public Quaternion[] rotacionesBarcos_enemigo = new Quaternion[5];





    //Posiciones y rotaciones separadas por barcos
    //BARCOS JUGADOR
    public Vector3 Posicion_barco_1;
    public Vector3 Posicion_barco_2;
    public Vector3 Posicion_barco_3;
    public Vector3 Posicion_portaAviones;
    public Vector3 Posicion_Submarino;
    public Quaternion rotacion_barco_1;
    public Quaternion rotacion_barco_2;
    public Quaternion rotacion_barco_3;
    public Quaternion rotacion_portaAviones;
    public Quaternion rotacion_Submarino;

    //BARCOS ENEMIGO
    public Vector3 Posicion_barco_1_enemigo;
    public Vector3 Posicion_barco_2_enemigo;
    public Vector3 Posicion_barco_3_enemigo;
    public Vector3 Posicion_portaAviones_enemigo;
    public Vector3 Posicion_Submarino_enemigo;
    public Quaternion rotacion_barco_1_enemigo;
    public Quaternion rotacion_barco_2_enemigo;
    public Quaternion rotacion_barco_3_enemigo;
    public Quaternion rotacion_portaAviones_enemigo;
    public Quaternion rotacion_Submarino_enemigo;



    //Como estan ordenados los barcos de la escena
    public string[] OrdenDenombreDeBarcos = new string[6];

    private void Awake() 
    {
       
    }
    

    // Start is called before the first frame update
    void Start()
    {
        if (DatosGlobales.instanciaGlobalScript == null)
        {
            DatosGlobales.instanciaGlobalScript =  this;
            DontDestroyOnLoad(this.gameObject);//este GameObject nunca se destruye
        }
        else
        {
            Destroy(this.gameObject);//este GameObject nunca se destruye
        }
        
        
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // /// <summary>guardo los barcos de la escena para tener guardados en la referencía de datos globales que no se destruye entre escenas</summary>
    // public void BuscarBarcosDeLaEscena()
    // {
    //     // barcosDeLaEscena = GameObject.FindGameObjectsWithTag("boat");
    //     //posiciones
    //     Posicion_barco_1 = GameObject.Find("barco_1").transform.position;
    //     Posicion_barco_2 = GameObject.Find("barco_2").transform.position;
    //     Posicion_barco_3 = GameObject.Find("barco_3").transform.position;
    //     Posicion_portaAviones = GameObject.Find("portaAviones").transform.position;
    //     Posicion_Submarino = GameObject.Find("submarino").transform.position;

    //     //rotaciones
    //     rotacion_barco_1 = GameObject.Find("barco_1").transform.rotation;
    //     rotacion_barco_2 = GameObject.Find("barco_2").transform.rotation;
    //     rotacion_barco_3 = GameObject.Find("barco_3").transform.rotation;
    //     rotacion_portaAviones = GameObject.Find("portaAviones").transform.rotation;
    //     rotacion_Submarino = GameObject.Find("submarino").transform.rotation;

    // }

    /// <summary>Referencia para cambiar la posicion de todos los barcos JUGADOR</summary>
    public void SetPosicionesBarcos(Vector3 barco1_posicion,Vector3 barco2_posicion,Vector3 barco3_posicion,Vector3 portaviones_posicion,Vector3 sumbarino_posicion)
    {
        Posicion_barco_1 = barco1_posicion;
        Posicion_barco_2 = barco2_posicion;
        Posicion_barco_3 = barco3_posicion;
        Posicion_portaAviones = portaviones_posicion;
        Posicion_Submarino = sumbarino_posicion;   
    }

    /// <summary>Referencia para cambiar la rotacion de todos los barcos</summary>
    public void SetRotacionesBarcos(Quaternion barco1_rotacion,Quaternion barco2_rotacion,Quaternion barco3_rotacion,Quaternion portaAviones_rotacion,Quaternion submarino_rotacion)
    {
        rotacion_barco_1 = barco1_rotacion;
        rotacion_barco_2 = barco2_rotacion;
        rotacion_barco_3 = barco3_rotacion;
        rotacion_portaAviones = portaAviones_rotacion;
        rotacion_Submarino = submarino_rotacion;
    }


    /// <summary>Referencia para cambiar la posicion de todos los barcos ENEMIGOS</summary>
    public void SetPosicionesBarcosEnemigos(Vector3 barco1_enemigo_posicion,Vector3 barco2_enemigo_posicion,Vector3 barco3_enemigo_posicion,Vector3 portaviones_enemigo_posicion,Vector3 sumbarino_enemigo_posicion)
    {
        Posicion_barco_1_enemigo = barco1_enemigo_posicion;
        Posicion_barco_2_enemigo = barco2_enemigo_posicion;
        Posicion_barco_3_enemigo = barco3_enemigo_posicion;
        Posicion_portaAviones_enemigo = portaviones_enemigo_posicion;
        Posicion_Submarino_enemigo = sumbarino_enemigo_posicion;  
    }


    /// <summary>Referencia para cambiar la rotacion de todos los barcos ENEMIGOS</summary>   
    public void SetRotacionesBarcosEnemigos(Quaternion barco1_enemigo_rotacion,Quaternion barco2_enemigo_rotacion,Quaternion barco3_enemigo_rotacion,Quaternion portaAviones_enemigo_rotacion,Quaternion submarino_enemigo_rotacion)
    {
        rotacion_barco_1_enemigo = barco1_enemigo_rotacion;
        rotacion_barco_2_enemigo = barco2_enemigo_rotacion;
        rotacion_barco_3_enemigo = barco3_enemigo_rotacion;
        rotacion_portaAviones_enemigo = portaAviones_enemigo_rotacion;
        rotacion_Submarino_enemigo = submarino_enemigo_rotacion;
    }    
}
