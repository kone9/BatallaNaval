using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using Photon.Pun;

public class GameHandlerRED : MonoBehaviourPunCallbacks,IPunObservable
{
    DatosGlobales _DatosGlobales;
    GameObject[] barcos; 
    GameObject[] barcosGrilla;

    //para guardar las posiciones de los barcos enemigos
    Vector3[] barcosEnemigosPosicionRed;
    Quaternion[] barcosEnemigosRotacionRed;


    public int cantidadDeAciertosJugador = 0;

    EnemigoHandler _EnemigoHandler;

    public GameObject fondoTablero;

    private bool puedoPresionarBoton = true;

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
        photonView.RPC("PosicionarBarcosDelEnemigo", //Nombre de la función que es llamada localmente
                RpcTarget.OthersBuffered,//para obtener los parámetros de otros
                _DatosGlobales.Posicion_barco_1,//Posicion del barco enemigo enviado por parametro
                _DatosGlobales.Posicion_barco_2,//Posicion del barco enemigo enviado por parametro
                _DatosGlobales.Posicion_barco_3,//Posicion del barco enemigo enviado por parametro
                _DatosGlobales.Posicion_portaAviones,//Posicion del barco enemigo enviado por parametro
                _DatosGlobales.Posicion_Submarino//Posicion del barco enemigo enviado por parametro
            );
        photonView.RPC("RotarBarcosDelEnemigo", //Nombre de la función que es llamada localmente
                RpcTarget.OthersBuffered,//para obtener los parámetros de otros
                _DatosGlobales.rotacion_barco_1,//Rotacion del barco enemigo enviado por parametro
                _DatosGlobales.rotacion_barco_2,//Rotacion del barco enemigo enviado por parametro
                _DatosGlobales.rotacion_barco_3,//Rotacion del barco enemigo enviado por parametro
                _DatosGlobales.rotacion_portaAviones,//Rotacion del barco enemigo enviado por parametro
                _DatosGlobales.rotacion_Submarino//Rotacion del barco enemigo enviado por parametro
            ); 

        if(!photonView.IsMine)//sino soy el que creo el servidor
        {
            fondoTablero.SetActive(true);//tablero de color rojo en el fondo
            puedoPresionarBoton = false;//los botones pueden ser presionados
        }   
    }

    [PunRPC]
    //hace que los barcos que representan al enemigo se posiciones segun la posicion del rival.
    void PosicionarBarcosDelEnemigo(Vector3 enemigo_barco_1_posicion,Vector3 enemigo_barco_2_posicion,Vector3 enemigo_barco_3_posicion,Vector3 enemigo_portaAviones_posicion,Vector3 enemigoPosicionSubmarino){
        //posiciones
        barco_1.transform.position = enemigo_barco_1_posicion;
        barco_2.transform.position = enemigo_barco_2_posicion;
        barco_3.transform.position = enemigo_barco_3_posicion;
        portaAviones.transform.position = enemigo_portaAviones_posicion;
        Submarino.transform.position = enemigoPosicionSubmarino;
    }


    [PunRPC]
    //hace que los barcos que representan al enemigo se roten segun la rotacion del rival.
    void RotarBarcosDelEnemigo(Quaternion enemigo_barco_1_rotacion,Quaternion enemigo_barco_2_rotacion,Quaternion enemigo_barco_3_rotacion,Quaternion enemigo_portaAviones_rotacion,Quaternion enemigo_Submarino_rotacion)
    {
        //rotaciones
        barco_1.transform.rotation = enemigo_barco_1_Rotacion;
        barco_2.transform.rotation = enemigo_barco_2_rotacion;
        barco_3.transform.rotation = enemigo_barco_3_rotacion;
        portaAviones.transform.rotation = enemigo_portaAviones_rotacion;
        Submarino.transform.rotation = enemigo_Submarino_rotacion;
    }



    private void AcomodarLosBarcos()//acomoda los barcos que estan en la pantalla de arriba,osea los del jugador
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


    /// <summary>Si es turno del jugador no activa el fondo de grilla<</summary>
    public void IsTurnoJugador()
    {
        fondoTablero.SetActive(false);
        puedoPresionarBoton = true;
        photonView.RPC("IsTurnoEnemigoAvisarRed", //Nombre de la función que es llamada localmente
                RpcTarget.OthersBuffered,//para obtener los parámetros de otros
                false,//Rotacion del barco enemigo enviado por parametro
                true//Rotacion del barco enemigo enviado por parametro
            );  
    }


    /// <summary>Si es turno del enemigo enciende un tablero de color rojo en el fondo y los botones ya no pueden ser presionados</summary>
    public void IsTurnoEnemigo()//se llama cuando se aprieta un elemento de la grilla donde no esta el barco
    {
        //aqui deshabilito el jugador actual
        fondoTablero.SetActive(true);//enciende un tablero de color rojo en el fondo
        puedoPresionarBoton = false;//los botones ya no pueden ser presionados

        //aqui habilito al enemigo
        photonView.RPC("IsTurnoEnemigoOJugadorAvisarRed", //Nombre de la función que es llamada localmente
                RpcTarget.OthersBuffered,//para llamar o obtener los datos de otros
                false,//apara un tablero de color rojo en el fondo
                true//los botones pueden ser presionados
            );  
    }


    [PunRPC]
    private void IsTurnoEnemigoOJugadorAvisarRed(bool fondoTableroRed,bool puedoPresionarBotonRed)
    {
        fondoTablero.SetActive(fondoTableroRed);
        puedoPresionarBoton = puedoPresionarBotonRed;
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
        //  if(stream.IsWriting)//si estoy escribiendo datos...Siempre soy yo el que escribre datos
        // {

        //     stream.SendNext(barcosEnemigosPosicionRed);
        //     stream.SendNext(enemigo_submarino_Posicion);
        // }
        // else //si esta escribiendo datos un avatar
        // {
        //     barcosEnemigosPosicionRed = (Vector3[])stream.ReceiveNext();
        //     enemigo_submarino_Posicion = (Vector3)stream.ReceiveNext();
        // }
    }
}
