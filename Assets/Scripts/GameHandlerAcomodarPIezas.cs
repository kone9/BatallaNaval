using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandlerAcomodarPIezas : MonoBehaviour
{
    DatosGlobales _DatosGlobales;

    GameObject[] barcos;

    GameObject barco_1;
    GameObject barco_2;
    GameObject barco_3;
    GameObject portaAviones;
    GameObject submarino;


    GameObject Grilla;

    bool playerListo = false;

    bool enemigoListo = false;
    
    public string NombreGameObjectGrilla;
    public Vector3 posicionGrilla;


    public GameObject grillaActual;
    public GameObject espera;

    public LayerMask grillaParaColision;

    int[,] occupied = new int[10, 10];//se usa como castillero imaginario

    private const int EAST = 1;
    private const int WEST = 3;
    private const int SOUTH = 2;
    private const int NORTH = 0;


	private void OnEnable()
	{
        GestorDeRed.OnPlayersConnected += DisableEspera;
	}

	private void OnDisable()
	{
        GestorDeRed.OnPlayersConnected -= DisableEspera;
    }

	private void DisableEspera()
	{
        espera.SetActive(false);
	}

	private void Awake() {
        _DatosGlobales = FindObjectOfType<DatosGlobales>();
        // barcos = GameObject.FindGameObjectsWithTag("boat");
        barco_1 = GameObject.Find("barco_1");
        barco_2 = GameObject.Find("barco_2");
        barco_3 = GameObject.Find("barco_3");
        portaAviones = GameObject.Find("portaAviones");
        submarino = GameObject.Find("submarino");
        
    }
    // Start is called before the first frame update
    void Start()
    {
        // GuardarPosicionBarcos();
        // GuardarRotacionesBarcos();
        // AcomodarLosBarcos();
    }


    /// <summary>Guarda la posicion de los barcos</summary>
    public void GuardarPosicionBarcos()
    {
        // Vector3[] posiciones = new Vector3[5];
        // for (int i = 0; i < barcos.Length; i++)
        // {
        //     posiciones[i] = barcos[i].transform.position;
        //     // _DatosGlobales.OrdenDenombreDeBarcos[i] = barcos[i].transform.name;
        // }
        // print("barcos acomodados de la siguiente manera" + _DatosGlobales.OrdenDenombreDeBarcos);
        Vector3 barco1_posicion =  barco_1.transform.position;
        Vector3 barco2_posicion =  barco_2.transform.position;
        Vector3 barco3_posicion =  barco_3.transform.position;
        Vector3 portaAviones_posicion =  portaAviones.transform.position;
        Vector3 submarino_posicion =  submarino.transform.position;
        _DatosGlobales.SetPosicionesBarcos(barco1_posicion,barco2_posicion,barco3_posicion,portaAviones_posicion,submarino_posicion);

    }

    /// <summary>Guarda la posicion de los barcos</summary>
    public void GuardarRotacionesBarcos()
    {
        // Quaternion[] rotaciones = new Quaternion[5];
        // for (int i = 0; i < barcos.Length; i++)
        // {
        //     rotaciones[i] = barcos[i].transform.rotation;
        // }
        // _DatosGlobales.SetRotacionesBarcos(rotaciones);
        Quaternion barco1_rotacion =  barco_1.transform.rotation;
        Quaternion barco2_rotacion =  barco_2.transform.rotation;
        Quaternion barco3_rotacion =  barco_3.transform.rotation;
        Quaternion portaAviones_rotacion =  portaAviones.transform.rotation;
        Quaternion submarino_rotacion =  submarino.transform.rotation;
        _DatosGlobales.SetRotacionesBarcos(barco1_rotacion,barco2_rotacion,barco3_rotacion,portaAviones_rotacion,submarino_rotacion);
    }

     /// <summary>Guarda la posicion de los barcos ENEMIGOS</summary>
    public void GuardarPosicionBarcosEnemigos()
    {

        Vector3 barco1_posicion = barco_1.transform.position;
        Vector3 barco2_posicion = barco_2.transform.position;
        Vector3 barco3_posicion = barco_3.transform.position;
        Vector3 portaAviones_posicion = portaAviones.transform.position;
        Vector3 submarino_posicion = submarino.transform.position;
        _DatosGlobales.SetPosicionesBarcosEnemigos(barco1_posicion,barco2_posicion,barco3_posicion,portaAviones_posicion,submarino_posicion);
    }

    /// <summary>Guarda la posicion de los barcos ENEMIGOS</summary>
    public void GuardarRotacionesBarcosEnemigo()
    {
        Quaternion barco1_rotacion =  barco_1.transform.rotation;
        Quaternion barco2_rotacion =  barco_2.transform.rotation;
        Quaternion barco3_rotacion =  barco_3.transform.rotation;
        Quaternion portaAviones_rotacion =  portaAviones.transform.rotation;
        Quaternion submarino_rotacion =  submarino.transform.rotation;
        _DatosGlobales.SetRotacionesBarcosEnemigos(barco1_rotacion,barco2_rotacion,barco3_rotacion,portaAviones_rotacion,submarino_rotacion);
    }
    
    /// <summary>Acomoda los barcos</summary>
    private void AcomodarLosBarcos()
    {
        // int indice = 0;

        // foreach (GameObject i in barcos)
        // {
        //     i.transform.position = _DatosGlobales.GetPosicionesBarcos()[indice];
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

        Posicion_barco_1.z = this.transform.position.z;
        Posicion_barco_2.z = this.transform.position.z;
        Posicion_barco_3.z = this.transform.position.z;
        Posicion_portaAviones.z = this.transform.position.z;
        Posicion_Submarino.z = this.transform.position.z;

        //posiciones
        barco_1.transform.position = Posicion_barco_1;
        barco_2.transform.position = Posicion_barco_2;
        barco_3.transform.position = Posicion_barco_3;
        portaAviones.transform.position = Posicion_portaAviones;
        submarino.transform.position = Posicion_Submarino;

        //rotaciones
        barco_1.transform.rotation = rotacion_barco_1;
        barco_2.transform.rotation = rotacion_barco_2;
        barco_3.transform.rotation = rotacion_barco_3;
        portaAviones.transform.rotation = rotacion_portaAviones;
        submarino.transform.rotation = rotacion_submarino;
           
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
        rayoParaDetectarSuelo();//uso el raycast para el suelo
    }

}
