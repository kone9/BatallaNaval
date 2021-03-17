using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandlerAcomodarPIezas : MonoBehaviour
{
    DatosGlobales _DatosGlobales;

    GameObject[] barcos;

    GameObject Grilla;

    bool playerListo = false;

    bool enemigoListo = false;
    
    public string NombreGameObjectGrilla;
    public Vector3 posicionGrilla;


    public GameObject grillaActual;

    public LayerMask grillaParaColision;

    int[,] occupied = new int[10, 10];//se usa como castillero imaginario

    private const int EAST = 1;
    private const int WEST = 3;
    private const int SOUTH = 2;
    private const int NORTH = 0;


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


    /// <summary>Guarda la posicion de los barcos</summary>
    /// <param>@None </param>
    public void GuardarPosicionBarcos()
    {
        Vector3[] posiciones = new Vector3[5];
        for (int i = 0; i < barcos.Length; i++)
        {
            posiciones[i] = barcos[i].transform.position;
            // _DatosGlobales.OrdenDenombreDeBarcos[i] = barcos[i].transform.name;
        }
        // print("barcos acomodados de la siguiente manera" + _DatosGlobales.OrdenDenombreDeBarcos);
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

     /// <summary>Guarda la posicion de los barcos ENEMIGOS</summary>
    public void GuardarPosicionBarcosEnemigos()
    {
        // Vector3[] posiciones = new Vector3[5];
        // for (int i = 0; i < barcos.Length; i++)
        // {
        //     posiciones[i] = barcos[i].transform.position;
        //     // _DatosGlobales.OrdenDenombreDeBarcos[i] = barcos[i].transform.name;
        // }
        Vector3 barco1 = GameObject.Find("Barco_1").transform.position;
        Vector3 barco2 = GameObject.Find("barco_2").transform.position;
        Vector3 barco3 = GameObject.Find("barco_3").transform.position;
        Vector3 portaAviones = GameObject.Find("portaAviones").transform.position;
        Vector3 submarino = GameObject.Find("submarino").transform.position;

        // print("barcos acomodados de la siguiente manera" + _DatosGlobales.OrdenDenombreDeBarcos);
        _DatosGlobales.SetPosicionesBarcosEnemigos(barco1,barco2,barco3,portaAviones,submarino);
    }

    /// <summary>Guarda la posicion de los barcos ENEMIGOS</summary>
    public void GuardarRotacionesBarcosEnemigo()
    {
        // Quaternion[] rotaciones = new Quaternion[5];
        // for (int i = 0; i < barcos.Length; i++)
        // {
        //     rotaciones[i] = barcos[i].transform.rotation;
        // }
        // _DatosGlobales.SetRotacionesBarcosEnemigos(rotaciones);
        Quaternion barco1 = GameObject.Find("Barco_1").transform.rotation;
        Quaternion barco2 = GameObject.Find("barco_2").transform.rotation;
        Quaternion barco3 = GameObject.Find("barco_3").transform.rotation;
        Quaternion portaAviones = GameObject.Find("portaAviones").transform.rotation;
        Quaternion submarino = GameObject.Find("submarino").transform.rotation;
        _DatosGlobales.SetRotacionesBarcosEnemigos(barco1,barco2,barco3,portaAviones,submarino);
    }
    
    /// <summary>Acomoda los barcos</summary>
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

    /// <summary>Para saber si el player esta listo para jugar, se usa en MULTIPLAYER ONLINE</summary>
    public bool GetPlayerListo()
    {
        return playerListo;
    }

    /// <summary>Para hacer que el player este listo o no este listo para jugar, se usa en MULTIPLAYER ONLINE y es un BOOLEANO</summary>
    public void SetPlayerListo(bool isPlayerListo)
    {
        playerListo = isPlayerListo;        
    }

    /// <summary>Para saber si el player esta listo para jugar, se usa en MULTIPLAYER ONLINE y es un BOOLEANO</summary>
    public bool GetEnemigoListo()
    {
        return enemigoListo;
    }

    /// <summary>Para hacer que el player este listo o no este listo para jugar, se usa en MULTIPLAYER ONLINE</summary>
    public void SetEnemigoListo(bool isEnemigoListo)
    {
        enemigoListo = isEnemigoListo;
    }


    //si estoy dentro de la grilla solo puedo mover
    public bool inGrid(int length,int lenghtBarcoDerecha,int lenghtBarcoIzquierda, int dir, int x, int y)
    {
        switch (dir)
        {
            case NORTH: //y-
                if (y >= length - 1 && x >= lenghtBarcoIzquierda  && x <= (9 - (lenghtBarcoDerecha)) )// es menos 1 porque comienza desce cero
                {
                    return true;
                }
                break;
            case SOUTH: //y+
                if (y <= (9 - (length - 1) ) && x >= lenghtBarcoDerecha  && x <= (9 - (lenghtBarcoIzquierda)) )//nueve porque comienza desde cero..Descuento 1 al tamaño de barco porque comienza desde cero
                {
                    return true;
                }
                break;
            case EAST:  //y+
                if (x <= (9 - (length - 1) )   && y >= lenghtBarcoIzquierda  && y <= (9 - (lenghtBarcoDerecha)) ) //si posicion en y es mayor a cero y si y es menor o igial a 10 menos tamaño del barco y x es mayor a cero y si y es menor o igual a nueve
                {
                    return true;
                }
                break;
            
            case WEST:  //y-
                if (x >= length - 1  && y >= lenghtBarcoDerecha  && y <= (9 - (lenghtBarcoIzquierda)) )                
                {
                    return true;
                }
                break;
        }

        return false;
    }

    /// <summary>Raycast para detectar el suelo</summary>
    void rayoParaDetectarSuelo()
    {
        Ray ray;
        RaycastHit rayHit;
        float rayLength = 100f;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out rayHit, rayLength,grillaParaColision))
        {
            Debug.DrawRay(rayHit.transform.position,Vector3.down* -rayLength,Color.red,0.1f);
            if (rayHit.transform.gameObject.CompareTag("cuadriculaColision"))
            {
                // print("Estoy arriba de la GRILLA " + rayHit.transform.gameObject.name);
                grillaActual = rayHit.transform.gameObject;
            }       
        }
    }




    // Update is called once per frame
    void Update()
    {
        rayoParaDetectarSuelo();
    }

}
