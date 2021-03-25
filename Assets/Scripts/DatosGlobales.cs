using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosGlobales : MonoBehaviour
{

    public static DatosGlobales instanciaGlobalScript;//para que no se destruya este GameObject entre escenas

    //Posiciones y rotaciones separadas por barcos
    //BARCOS JUGADOR
    public Vector3 Posicion_barco_1;//posicion
    public Vector3 Posicion_barco_2;//posicion
    public Vector3 Posicion_barco_3;//posicion
    public Vector3 Posicion_portaAviones;//posicion
    public Vector3 Posicion_Submarino;//posicion
    public Quaternion rotacion_barco_1;//Rotacion
    public Quaternion rotacion_barco_2;//Rotacion
    public Quaternion rotacion_barco_3;//Rotacion
    public Quaternion rotacion_portaAviones;//Rotacion
    public Quaternion rotacion_Submarino;//Rotacion

    //BARCOS ENEMIGO
    public Vector3 Posicion_barco_1_enemigo;//posicion
    public Vector3 Posicion_barco_2_enemigo;//posicion
    public Vector3 Posicion_barco_3_enemigo;//posicion
    public Vector3 Posicion_portaAviones_enemigo;//posicion
    public Vector3 Posicion_Submarino_enemigo;//posicion
    public Quaternion rotacion_barco_1_enemigo;//Rotacion
    public Quaternion rotacion_barco_2_enemigo;//Rotacion
    public Quaternion rotacion_barco_3_enemigo;//Rotacion
    public Quaternion rotacion_portaAviones_enemigo;//Rotacion
    public Quaternion rotacion_Submarino_enemigo;//Rotacion

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
