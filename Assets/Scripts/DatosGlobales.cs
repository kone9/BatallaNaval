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





    //Posciones y rotaciones separadas por barcos
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
       
        BuscarBarcosDeLaEscena();//busca los barcos de la escena
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /// <summary>guardo los barcos de la escena para tener guardados en la referencía de datos globales que no se destruye entre escenas</summary>
    public void BuscarBarcosDeLaEscena()
    {
        barcosDeLaEscena = GameObject.FindGameObjectsWithTag("boat");
    }


    /// <summary>Referencia para cambiar la posicion de todos los barcos JUGADOR</summary>
    /// <param>@Vector3[] </param>
    public void SetPosicionesBarcos(Vector3[] posiciones)
    {
        for(int i = 0;i < posicionesBarcos.Length; i++)
        {
            posicionesBarcos[i] = posiciones[i];
            switch (i)
            {
                case 0:
                    Posicion_barco_1 = posiciones[i];
                    break;
                case 1:
                    Posicion_barco_2 = posiciones[i];
                    break;
                case 2:
                    Posicion_barco_3 = posiciones[i];
                    break;
                case 3:
                    Posicion_portaAviones = posiciones[i];
                    break;
                case 4:
                    Posicion_Submarino = posiciones[i];
                    break;
                default:
                    break;
            }
        }   
    }

    /// <summary>Referencia para cambiar la rotacion de todos los barcos</summary>
    public void SetRotacionesBarcos(Quaternion[] rotaciones)
    {
        for(int i = 0;i < rotacionesBarcos.Length; i++)
        {
            rotacionesBarcos[i] = rotaciones[i];
            switch (i)
            {
                case 0:
                    rotacion_barco_1 = rotaciones[i];
                    break;
                case 1:
                    rotacion_barco_2 = rotaciones[i];
                    break;
                case 2:
                    rotacion_barco_3 = rotaciones[i];
                    break;
                case 3:
                    rotacion_portaAviones = rotaciones[i];
                    break;
                case 4:
                    rotacion_Submarino = rotaciones[i];
                    break;
                default:
                    break;
            }
        }
        
    }


    /// <summary>Referencia para cambiar la posicion de todos los barcos ENEMIGOS</summary>
    /// <param>@Vector3[] </param>
    // public void SetPosicionesBarcosEnemigos(Vector3[] posiciones)
    // {
    //     for(int i = 0;i < posicionesBarcos_enemigo.Length; i++)
    //     {
    //         posicionesBarcos_enemigo[i] = posiciones[i];
    //         switch (i)
    //         {
    //             case 0:
    //                 Posicion_barco_1_enemigo = posiciones[i];
    //                 break;
    //             case 1:
    //                 Posicion_barco_2_enemigo = posiciones[i];
    //                 break;
    //             case 2:
    //                 Posicion_barco_3_enemigo = posiciones[i];
    //                 break;
    //             case 3:
    //                 Posicion_portaAviones_enemigo = posiciones[i];
    //                 break;
    //             case 4:
    //                 Posicion_Submarino_enemigo = posiciones[i];
    //                 break;
    //             default:
    //                 break;
    //         }
    //     }   
    // }
    public void SetPosicionesBarcosEnemigos(Vector3 barco1_enemigo_posicion,Vector3 barco2_enemigo_posicion,Vector3 barco3_enemigo_posicion,Vector3 portaviones_enemigo_posicion,Vector3 sumbarino_enemigo_posicion)
    {
        Posicion_barco_1_enemigo = barco1_enemigo_posicion;
        Posicion_barco_2_enemigo =barco2_enemigo_posicion;
        Posicion_barco_3_enemigo = barco3_enemigo_posicion;
        Posicion_portaAviones_enemigo = portaviones_enemigo_posicion;
        Posicion_Submarino_enemigo = sumbarino_enemigo_posicion;  
    }


    /// <summary>Referencia para cambiar la rotacion de todos los barcos ENEMIGOS</summary>
    // public void SetRotacionesBarcosEnemigos(Quaternion[] rotaciones)
    // {
    //     for(int i = 0;i < rotacionesBarcos.Length; i++)
    //     {
    //         rotacionesBarcos[i] = rotaciones[i];
    //         switch (i)
    //         {
    //             case 0:
    //                 rotacion_barco_1_enemigo = rotaciones[i];
    //                 break;
    //             case 1:
    //                 rotacion_barco_2_enemigo = rotaciones[i];
    //                 break;
    //             case 2:
    //                 rotacion_barco_3_enemigo = rotaciones[i];
    //                 break;
    //             case 3:
    //                 rotacion_portaAviones_enemigo = rotaciones[i];
    //                 break;
    //             case 4:
    //                 rotacion_Submarino_enemigo = rotaciones[i];
    //                 break;
    //             default:
    //                 break;
    //         }
    //     }
    // }    
    public void SetRotacionesBarcosEnemigos(Quaternion barco1_enemigo_rotacion,Quaternion barco2_enemigo_rotacion,Quaternion barco3_enemigo_rotacion,Quaternion portaAviones_enemigo_rotacion,Quaternion submarino_enemigo_rotacion)
    {
        rotacion_barco_1_enemigo = barco1_enemigo_rotacion;
        rotacion_barco_2_enemigo = barco2_enemigo_rotacion;
        rotacion_barco_3_enemigo = barco3_enemigo_rotacion;
        rotacion_portaAviones_enemigo = portaAviones_enemigo_rotacion;
        rotacion_Submarino_enemigo = submarino_enemigo_rotacion;
    }    

    /// <summary>Devuelve las posiciones de todos los barcos en un arreglo de tipo vector3</summary>
    /// <param>@None </param>
    public Vector3[] GetPosicionesBarcos()
    {
        Vector3[] posiciones = new Vector3[5];
        for (int i = 0; i < posicionesBarcos.Length; i++)
        {
            posiciones[i] = posicionesBarcos[i];
        }
        return posiciones;
    }

    
    /// <summary>Devuelve un arreglo de las rotaciónes de los barcos en quaternions</summary>
    /// <param>@None </param>
    public Quaternion[] GetRotacionBarcos()
    {
        Quaternion[] rotaciones = new Quaternion[5];
        for (int i = 0; i < rotacionesBarcos.Length; i++)
        {
            rotaciones[i] = rotacionesBarcos[i];
        }
        return rotaciones;
    }






     /// <summary>verifica el tipo de barco en esa posicion sobre todos los barcos guardados en datos globales y Devuelve verdadero cuando el barco es identico..Importante para acomodar los barcos</summary>
    // public bool VerificarTipoDeBarcoEnPosicion(Vector3 posicion,GameObject barcoActual)
    // {

    //     bool barcoCorrecto = false;
    //     foreach (GameObject i in barcosDeLaEscena)//esto reccorre todos los barcos guardados de la escena
    //     {
    //         //Si la posición ingresada es igual a la del barco
    //         //y si el nombre del barco es el correcto el mismo
    //         //Devuelvo que son los mismos barcos
    //         if(posicion == i.transform.position && barcoActual.name == "Barco_1")
    //         {
    //             barcoCorrecto = true;
    //         }
    //         if(posicion == i.transform.position && barcoActual.name == "Barco_1")
    //         {
    //             barcoCorrecto = true;
    //         }
    //         if(posicion == i.transform.position && barcoActual.name == "Barco_1")
    //         {
    //             barcoCorrecto = true;
    //         }
    //         if(posicion == i.transform.position && barcoActual.name == "Barco_1")
    //         {
    //             barcoCorrecto = true;
    //         }
    //         if(posicion == i.transform.position && barcoActual.name == "Barco_1")
    //         {
    //             barcoCorrecto = true;
    //         }
    //     }
    //     return barcoCorrecto;
    // }

    // public GameObject VerificarTipoDeBarcoEnPosicion(Vector3 posicion)
    // {

    //     GameObject barcoCorrecto = null;
    //     foreach (GameObject i in barcosDeLaEscena)//esto reccorre todos los barcos guardados de la escena
    //     {
    //         if(posicion == i.transform.position)
    //         {
    //             barcoCorrecto = i;
    //         }
    //     }
    //     return barcoCorrecto;
    // }

}
