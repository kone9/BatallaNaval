using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosGlobales : MonoBehaviour
{

    public static DatosGlobales instanciaGlobalScript;

    public Vector3[] posicionesBarcos = new Vector3[5];
    public Quaternion[] rotacionesBarcos = new Quaternion[5];


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

    /// <summary>Referencia para cambiar la posicion de todos los barcos</summary>
    /// <param>@Vector3[] </param>
    public void SetPosicionesBarcos(Vector3[] posiciones)
    {
        for(int i = 0;i < posicionesBarcos.Length; i++)
        {
            posicionesBarcos[i] = posiciones[i];
        }
        
    }

    /// <summary>Referencia para cambiar la rotacion de todos los barcos</summary>
    public void SetRotacionesBarcos(Quaternion[] rotaciones)
    {
        for(int i = 0;i < rotacionesBarcos.Length; i++)
        {
            rotacionesBarcos[i] = rotaciones[i];
        }
        
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




}
