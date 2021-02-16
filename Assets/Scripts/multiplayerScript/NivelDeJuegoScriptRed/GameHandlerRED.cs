using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using Photon.Pun;

public class GameHandlerRED : MonoBehaviourPunCallbacks,IPunObservable
{
    DatosGlobales _DatosGlobales;
    DatosGlobalesRed _DatosGlobalesRed;
    GameObject[] barcos;
    GameObject[] barcosGrilla;

    Vector3[] barcosEnemigosPosicionRed;
    Quaternion[] barcosEnemigosRotacionRed;

    public int cantidadDeAciertosJugador = 0;

    EnemigoHandler _EnemigoHandler;

    public GameObject fondoTablero;

    private bool puedoPresionarBoton = true;

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


    private void Awake() {
       
        _DatosGlobales = FindObjectOfType<DatosGlobales>();
        _DatosGlobalesRed = FindObjectOfType<DatosGlobalesRed>();
        _EnemigoHandler = FindObjectOfType<EnemigoHandler>();
        _DatosGlobales.BuscarBarcosDeLaEscena();
        barcos = GameObject.FindGameObjectsWithTag("boat");
        barcosGrilla = GameObject.FindGameObjectsWithTag("barcosGrilla");
        buscarBarcos();
    }

    //busca todos los barcos de la escena por su nombre para evitar problemas
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
        StartCoroutine("cargarBarcosRivalRed");//carga las posiciones de los barcos desde la red
    }


    IEnumerator cargarBarcosRivalRed()
    {
        yield return new WaitForSeconds(1);
        photonView.RPC("PosicionarBarcosSegunSeaJugadorOEnemigo",RpcTarget.All,_DatosGlobalesRed.SoyJugador);
        yield return new WaitForSeconds(2);
        
        AcomodarLosBarcosGrilla();
        
        foreach (Vector3 i in barcosEnemigosPosicionRed)
        {
            print(i);
        }
        //print(barcosEnemigosRed);
    }


    [PunRPC]
    //hace que los barcos se posiciones segun sea el jugador o el rival.
    //si es el jugador se posiciona en la parte de arriba
    //si es el enemigo se posiciona en la parte de abajo.
    void PosicionarBarcosSegunSeaJugadorOEnemigo(bool isMine)
    {
        if(isMine)
        {
            barcosEnemigosPosicionRed = _DatosGlobales.GetPosicionesBarcos();
            barcosEnemigosRotacionRed = _DatosGlobales.GetRotacionBarcos();
        }
        if(!isMine)
        {
            barcosEnemigosPosicionRed = _DatosGlobales.GetPosicionesBarcos();
            barcosEnemigosRotacionRed = _DatosGlobales.GetRotacionBarcos();
        }    
    }

    private void AcomodarLosBarcos()//acomoda los barcos que estan en la pantalla de arriba
    {
        Vector3 Posicion_barco_1 = _DatosGlobales.Posicion_barco_1;
        Vector3 Posicion_barco_2 = _DatosGlobales.Posicion_barco_2;
        Vector3 Posicion_barco_3 = _DatosGlobales.Posicion_barco_3;
        Vector3 Posicion_portaAviones = _DatosGlobales.Posicion_portaAviones;
        Vector3 Posicion_Submarino = _DatosGlobales.Posicion_Submarino;

        Posicion_barco_1.z += 250;
        Posicion_barco_2.z += 250;
        Posicion_barco_3.z += 250;
        Posicion_portaAviones.z += 250;
        Posicion_Submarino.z += 250;

        barco_1_jugador.transform.position = Posicion_barco_1;
        barco_2_jugador.transform.position = Posicion_barco_2;
        barco_3_jugador.transform.position = Posicion_barco_3;
        PortaAviones_jugador.transform.position = Posicion_portaAviones;
        submarino_jugador.transform.position = Posicion_Submarino;                    
        // int indice = 0;
        // foreach (GameObject i in barcos)//los barcos son buscados usando etiquetas posiblemente estan ordenados aleatoriamente
        // {
        //     //acomodar posición
        //     GameObject barcoActual = _DatosGlobales.VerificarTipoDeBarcoEnPosicion(_DatosGlobales.GetPosicionesBarcos()[indice]);
            
        //     print("el nombre del barco es :" + i.transform.name);
        //     i.transform.position = new Vector3(
        //         _DatosGlobales.GetPosicionesBarcos()[indice].x,
        //         _DatosGlobales.GetPosicionesBarcos()[indice].y,
        //         _DatosGlobales.GetPosicionesBarcos()[indice].z + 250
        //     );
            
        //     //acomodar rotación
        //     i.transform.rotation = _DatosGlobales.GetRotacionBarcos()[indice];
        //     indice += 1;
        // }
    }

    private void AcomodarLosBarcosGrilla()//acomoda los abrcos de la pantalla grande son los de los enemigos
    {
        barco_1.transform.position = _DatosGlobales.Posicion_barco_1;
        barco_2.transform.position =_DatosGlobales.Posicion_barco_2;
        barco_3.transform.position = _DatosGlobales.Posicion_barco_3;
        portaAviones.transform.position = _DatosGlobales.Posicion_portaAviones;
        Submarino.transform.position = _DatosGlobales.Posicion_Submarino;
        // int indice = 0;
        // foreach (GameObject i in barcosGrilla)
        // {
        //     //acomodar posición
        //     i.transform.position = posiciones[indice];
        //     //acomodar rotación
        //     i.transform.rotation = barcosEnemigosRotacionRed[indice];
        //     indice += 1;
        // }
    }


    /// <summary>Si es turno del jugador no activa el fondo de grilla<</summary>
    public void IsTurnoJugador()
    {
        fondoTablero.SetActive(false);
        puedoPresionarBoton = true;
    }

    /// <summary>Si es turno del enemigo activa el fondo de grilla</summary>
    public void IsTurnoEnemigo()
    {
        fondoTablero.SetActive(true);
        puedoPresionarBoton = false;
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

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
         if(stream.IsWriting)//si estoy escribiendo datos...Siempre soy yo el que escribre datos
        {

            stream.SendNext(barcosEnemigosPosicionRed);
        }
        else //si esta escribiendo datos un avatar
        {
            barcosEnemigosPosicionRed = (Vector3[])stream.ReceiveNext();

        }
    }
}
