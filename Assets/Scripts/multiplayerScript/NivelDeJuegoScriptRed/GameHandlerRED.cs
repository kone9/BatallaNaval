using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using Photon.Pun;

public class GameHandlerRED : MonoBehaviourPunCallbacks,IPunObservable
{
    DatosGlobales _DatosGlobales;
    // GameObject[] barcos; 
    // GameObject[] barcosGrilla;

    // //para guardar las posiciones de los barcos enemigos
    // Vector3[] barcosEnemigosPosicionRed;
    // Quaternion[] barcosEnemigosRotacionRed;


    public int cantidadDeAciertosJugador = 0;
    
    public int cantidadDeBarcosJugador = 5;
    public int cantidadDeBarcosEnemigo = 5;

    EnemigoHandler _EnemigoHandler;

    public GameObject fondoTablero;

    private bool puedoPresionarBoton = true;

    public GameObject ui_Winner;
    public GameObject ui_GameOver;

    public Animator animacionLuzDecoradoRoja;

/////////////////////////////////////////////////////////
    //referencia a todos los barcos de la escena del JUGADOR
    private GameObject barco_1_enemigo; //enemigo
    private GameObject barco_2_enemigo; //enemigo
    private GameObject barco_3_enemigo; //enemigo
    private GameObject portaAviones_enemigo; //enemigo
    private GameObject Submarino_enemigo; //enemigo

    private GameObject barco_1_jugador; //jugador
    private GameObject barco_2_jugador; //jugador
    private GameObject barco_3_jugador; //jugador
    private GameObject PortaAviones_jugador; //jugador
    private GameObject submarino_jugador; //jugador
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

//bardeadas UI
    ////////////////////////////////////////////////
    [SerializeField]
    private List<GameObject> bardeadaJugadorAcertarDisparo;//cuando el jugador acierta disparo
    [SerializeField]
    private List<GameObject> bardeadaJugadorErrarDisparo;//cuando el jugador no acierta el disparo
    [SerializeField]
    private List<GameObject> bardeadaEnemigoAcertarDisparo;//cuando el enemigo acierta disparo en jugador
    [SerializeField]
    private List<GameObject> bardeadaEnemigoErrarDisparo;//cuando el enemigo no acierta el disparo

    [SerializeField]
    private GameObject bardeadaJugadorDestruyoBarco;
    
    [SerializeField]
    private GameObject bardeadaEnemigoDestruyoBarco;

    [SerializeField]
    private GameObject bardeadaEstamosPerdiendo;

    [SerializeField]
    private GameObject bardeadaEstamosGanando;

//////////////////////////////////////////////////////

    private void Awake() {
       
        _DatosGlobales = FindObjectOfType<DatosGlobales>();
        _EnemigoHandler = FindObjectOfType<EnemigoHandler>();
        // barcos = GameObject.FindGameObjectsWithTag("boat");
        // barcosGrilla = GameObject.FindGameObjectsWithTag("barcosGrilla");
        buscarBarcos();
    }

    //busca todos los barcos de la escena por su nombre para evitar problemas
    void buscarBarcos()
    {
        //barcos de la grilla cuadro de abajo
        barco_1_enemigo = GameObject.Find("barco_1_enemigo");
        barco_2_enemigo = GameObject.Find("barco_2_enemigo");
        barco_3_enemigo = GameObject.Find("barco_3_enemigo");
        portaAviones_enemigo = GameObject.Find("portaAviones_enemigo");
        Submarino_enemigo  = GameObject.Find("submarino_enemigo");
        //barcos del jugador cuadro de arriba
        barco_1_jugador = GameObject.Find("barco_1");
        barco_2_jugador = GameObject.Find("barco_2");
        barco_3_jugador = GameObject.Find("barco_3");
        PortaAviones_jugador = GameObject.Find("portaAviones");
        submarino_jugador = GameObject.Find("submarino");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        AcomodarLosBarcos();//acomoda los barcos del jugador en la pantalla de arriba
        // StartCoroutine("cargarBarcosRivalRed");//carga las posiciones de los barcos desde la red
        cargarBarcosRivalRed();
    }

    /// <summary>carga las posiciones de los barcos desde la red</summary>
    void cargarBarcosRivalRed()
    {
        // yield return new WaitForSeconds(0);
        // yield return null;
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
            animacionLuzDecoradoRoja.SetBool("isTurnEnemy",true);
        }   
    }

    /// <summary>Acomoda los barcos del enemigo usando la posición por parametro en la red porque es PunRPC. Hace que los barcos que representan al enemigo se posiciones segun la posicion del rival.</summary>
    [PunRPC]
    void PosicionarBarcosDelEnemigo(Vector3 enemigo_barco_1_posicion,Vector3 enemigo_barco_2_posicion,Vector3 enemigo_barco_3_posicion,Vector3 enemigo_portaAviones_posicion,Vector3 enemigoPosicionSubmarino){
        //posiciones
        barco_1_enemigo.transform.position = enemigo_barco_1_posicion;
        barco_2_enemigo.transform.position = enemigo_barco_2_posicion;
        barco_3_enemigo.transform.position = enemigo_barco_3_posicion;
        portaAviones_enemigo.transform.position = enemigo_portaAviones_posicion;
        Submarino_enemigo.transform.position = enemigoPosicionSubmarino;
    }


    /// <summary>Rota los barcos del enemigo usando la posición por parametro en la red porque es PunRPC. Hace que los barcos que representan al enemigo se roten segun la rotacion del rival.</summary>
    [PunRPC]
    void RotarBarcosDelEnemigo(Quaternion enemigo_barco_1_rotacion,Quaternion enemigo_barco_2_rotacion,Quaternion enemigo_barco_3_rotacion,Quaternion enemigo_portaAviones_rotacion,Quaternion enemigo_Submarino_rotacion)
    {
        //rotaciones
        barco_1_enemigo.transform.rotation = enemigo_barco_1_Rotacion;
        barco_2_enemigo.transform.rotation = enemigo_barco_2_rotacion;
        barco_3_enemigo.transform.rotation = enemigo_barco_3_rotacion;
        portaAviones_enemigo.transform.rotation = enemigo_portaAviones_rotacion;
        Submarino_enemigo.transform.rotation = enemigo_Submarino_rotacion;
    }

    /// <summary>acomoda los barcos que estan en la pantalla de arriba,osea los del jugador.</summary>
    private void AcomodarLosBarcos()
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
        //aqui habilito el jugador actual
        fondoTablero.SetActive(false);
        puedoPresionarBoton = true;
        animacionLuzDecoradoRoja.SetBool("isTurnEnemy",false);
        //aqui deshabilito al enemigo
        photonView.RPC("IsTurnoEnemigoAvisarRed", //Nombre de la función que es llamada localmente
                RpcTarget.OthersBuffered,//para obtener los parámetros de otros
                true,////apara un tablero de color rojo en el fondo
                false,//los botones pueden ser presionados
                true//luz roja que aparace con el tablero de no puedo jugar
            );  
    }


    /// <summary>Si es turno del enemigo enciende un tablero de color rojo en el fondo y los botones ya no pueden ser presionados</summary>
    public void IsTurnoEnemigo()//se llama cuando se aprieta un elemento de la grilla donde no esta el barco
    {
        //aqui deshabilito el jugador actual
        fondoTablero.SetActive(true);//enciende un tablero 
        puedoPresionarBoton = false;//los botones ya no pueden ser presionados
        animacionLuzDecoradoRoja.SetBool("isTurnEnemy",true);//luz que aparece con el tablero
        //aqui habilito al enemigo
        photonView.RPC("IsTurnoEnemigoOJugadorAvisarRed", //Nombre de la función que es llamada localmente
                RpcTarget.OthersBuffered,//para llamar o obtener los datos de otros
                false,//saca el tablero de color rojo del fondo
                true,//los botones pueden ser presionados
                false//luz roja que aparace con el tablero deja de estar visible
            );  
    }

    /// <summary>Ejecuta todo esto, pero en la red</summary>
    [PunRPC]
    private void IsTurnoEnemigoOJugadorAvisarRed(bool fondoTableroRed,bool puedoPresionarBotonRed,bool cambiarColorBotones)
    {
        fondoTablero.SetActive(fondoTableroRed);
        puedoPresionarBoton = puedoPresionarBotonRed;
        animacionLuzDecoradoRoja.SetBool("isTurnEnemy",cambiarColorBotones);
    }

    /// <summary>Retorna un bolean "si puedo o no puedo" presionar Boton</summary>
    public bool GetPuedoPresionarBoton()
    {
        return this.puedoPresionarBoton;
    }

    public void SetPuedoPresionarBoton(bool PresionaBoton)
    {
        this.puedoPresionarBoton = PresionaBoton;
    }

    /// <summary>Cambia al nivel GameOverWinner</summary>
    public void GameOverWinner()
    {
       ui_Winner.SetActive(true);
    }

    /// <summary>Cambia al nivel GameOverLose</summary>
    public void GameOverLose()
    {
        ui_GameOver.SetActive(true);
    }


    /// <summary>activa y desactiva mensajes cuando el jugador SI acierta disparo</summary>
    public IEnumerator Mensaje_bardeadaJugadorAcertarDisparo()
    {
        int fraseAleatoria = Random.Range(0,bardeadaJugadorAcertarDisparo.Count - 1);
        bardeadaJugadorAcertarDisparo[fraseAleatoria].gameObject.SetActive(true);//activo game object
        yield return new WaitForSeconds(2);
        bardeadaJugadorAcertarDisparo[fraseAleatoria].gameObject.SetActive(false);//activo game object
    }
    /// <summary>activa y desactiva mensajes cuando el jugador NO acierta disparo</summary>
    public IEnumerator Mensaje_bardeadaJugadorErrarDisparo()
    {
        int fraseAleatoria = Random.Range(0,bardeadaJugadorErrarDisparo.Count - 1);
        bardeadaJugadorErrarDisparo[fraseAleatoria].gameObject.SetActive(true);//activo game object
        yield return new WaitForSeconds(1);
        bardeadaJugadorErrarDisparo[fraseAleatoria].gameObject.SetActive(false);//activo game object
    }
    /// <summary>activa y desactiva mensajes cuando el jugador Destruyo el barco completamente</summary>
    public IEnumerator Mensaje_bardeadaJugadorDestruyoBarco()
    {
        bardeadaJugadorDestruyoBarco.gameObject.SetActive(true);//activo game object
        yield return new WaitForSeconds(2);
        bardeadaJugadorDestruyoBarco.gameObject.SetActive(false);//activo game object
    }
    /// <summary>activa y desactiva mensajes cuando el enemigo SI acierta disparo</summary>
    public IEnumerator Mensaje_bardeadaEnemigoAcertarDisparo()
    {
        int fraseAleatoria = Random.Range(0,bardeadaEnemigoAcertarDisparo.Count - 1);
        bardeadaEnemigoAcertarDisparo[fraseAleatoria].gameObject.SetActive(true);//activo game object
        yield return new WaitForSeconds(2);
        bardeadaEnemigoAcertarDisparo[fraseAleatoria].gameObject.SetActive(false);//activo game object

    }

     /// <summary>activa y desactiva mensajes cuando el enemigo NO acierta disparo</summary>
    public IEnumerator Mensaje_bardeadaEnemigoErrarDisparo()
    {
        int fraseAleatoria = Random.Range(0,bardeadaEnemigoErrarDisparo.Count - 1);
        bardeadaEnemigoErrarDisparo[fraseAleatoria].gameObject.SetActive(true);//activo game object
        yield return new WaitForSeconds(1);
        bardeadaEnemigoErrarDisparo[fraseAleatoria].gameObject.SetActive(false);//activo game object
    }
    
    /// <summary>activa y desactiva mensajes cuando el enemigo Destruyo el barco completamente</summary>
    public IEnumerator Mensaje_bardeadaEnemigoDestruyoBarco()
    {
        bardeadaEnemigoDestruyoBarco.gameObject.SetActive(true);//activo game object
        yield return new WaitForSeconds(2);
        bardeadaEnemigoDestruyoBarco.gameObject.SetActive(false);//activo game object
    }

    /// <summary>activa y desactiva mensajes cuando el jugador esta perdiendo</summary>
    public IEnumerator Mensaje_EstamosPerdiendo()
    {
        bardeadaEstamosPerdiendo.gameObject.SetActive(true);//activo game object
        yield return new WaitForSeconds(2);
        bardeadaEstamosPerdiendo.gameObject.SetActive(false);//activo game object
    }

    /// <summary>activa y desactiva mensajes cuando el jugador esta perdiendo</summary>
    public IEnumerator Mensaje_EstamosGanando()
    {
        bardeadaEstamosGanando.gameObject.SetActive(true);//activo game object
        yield return new WaitForSeconds(3);
        bardeadaEstamosGanando.gameObject.SetActive(false);//activo game object
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
