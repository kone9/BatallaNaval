using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandlerAcomodarPIezas : MonoBehaviour
{
    DatosGlobales _DatosGlobales;
    GameObject[] barcos;

    GameObject Grilla;
    
    public string NombreGameObjectGrilla;
    public Vector3 posicionGrilla;
    private void Awake() {
         _DatosGlobales = FindObjectOfType<DatosGlobales>();
         barcos = GameObject.FindGameObjectsWithTag("boat");
    }
    // Start is called before the first frame update
    void Start()
    {
        GuardarPosicionBarcos();
        GuardarRotacionesBarcos();
        AcomodarLosBarcos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /// <summary>Guarda la posicion de los barcos</summary>
    /// <param>@None </param>
    public void GuardarPosicionBarcos()
    {
        Vector3[] posiciones = new Vector3[5];
        for (int i = 0; i < barcos.Length; i++)
        {
            posiciones[i] = barcos[i].transform.position;
        }
        _DatosGlobales.SetPosicionesBarcos(posiciones);
    }
    
    /// <summary>Guarda la posicion de los barcos</summary>

    public void GuardarRotacionesBarcos()
    {
        Quaternion[] rotaciones = new Quaternion[5];
        for (int i = 0; i < barcos.Length; i++)
        {
            rotaciones[i] = barcos[i].transform.rotation;
        }
        _DatosGlobales.SetRotacionesBarcos(rotaciones);
    }

    /// <summary>Acomoda los barcos</summary>
    /// <param>@None </param>
    private void AcomodarLosBarcos()
    {
        int indice = 0;
        foreach (GameObject i in barcos)
        {
            i.transform.position = _DatosGlobales.GetPosicionesBarcos()[indice];
            indice += 1;
        }
    }

    /// <summary>Obtiene el elemento de la grilla que esta el mouse por arriba</summary>
    public void SetGrilla(GameObject grillaActual)
    {
        Grilla = grillaActual;
        NombreGameObjectGrilla = grillaActual.transform.name;
        posicionGrilla = grillaActual.transform.localPosition;
    }

    /// <summary>devuelve el elemento de la grilla que esta el mouse por arriba</summary>
    public GameObject GetGrilla()
    {
        return Grilla;
    }

}
