using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public class BarcoTriggerRed : MonoBehaviourPunCallbacks,IPunObservable
{
    public GameObject fuego;
    public BoxCollider _BoxCollider;
    private PhotonView _photonView;
    GameHandlerRED _GameHandlerRED;

    public BoxCollider[] overlappers;
    public LayerMask isOverlapper;


    BarcoHandler _BarcoHandler;
    Animator _Animator;

    AudioSource sonidoWinner;

    GameObject[] sonidoBarcoEnemigoDestruido;
    AudioSource musicaJugandoContraEnemigo;
    GameObject[] sound_hit;
    AudioSource audio_hit_Own;//sonido hit pero para el enemigo
    AudioSource audio_sink_Own;//sonido hundio barco  para el enemigo

    AudioSource SonidoGameOver;//sonido GameOver cuando termino el juego

    //ProbandoGithubDes
    
    private void Awake()
    {
        _BoxCollider = GetComponent<BoxCollider>();
        _GameHandlerRED = FindObjectOfType<GameHandlerRED>();
        _photonView = GetComponent<PhotonView>();

        _BarcoHandler = transform.parent.GetComponent<BarcoHandler>();
        _Animator = transform.parent.GetComponent<Animator>();
        sound_hit = GameObject.FindGameObjectsWithTag("hit");
        sonidoWinner = GameObject.Find("SonidoWinner").GetComponent<AudioSource>();
        sonidoBarcoEnemigoDestruido = GameObject.FindGameObjectsWithTag("SonidoBarcoEnemigoDestruido");//referencia a la sonido barcos destruidos
        musicaJugandoContraEnemigo = GameObject.Find("MusicaJugandoContraEnemigo").GetComponent<AudioSource>();//referencia a la música del juego

        audio_hit_Own = GameObject.Find("hit_Own").GetComponent<AudioSource>();
        audio_sink_Own = GameObject.Find("sink_Own").GetComponent<AudioSource>();
        SonidoGameOver = GameObject.Find("SonidoGameOver").GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnMouseDown() 
    { 
        Diparar();
    }


     /// <summary>Disparo contra los barcos y hago todo lo referenciado a disparar</summary>
    void Diparar()
    {
        if(_GameHandlerRED.GetPuedoPresionarBoton())//si puedo presionar boton
        {
            // importante aca esta la lógica principal de disparar
            if(_BarcoHandler.vidas > 1 && _GameHandlerRED.cantidadDeAciertosJugador < 21)//si vidas de barco es mayor a uno
            {
                sound_hit[Random.Range(0,sound_hit.Length)].GetComponent<AudioSource>().Play();
                _GameHandlerRED.SetPuedoPresionarBoton(false);//no puedo presionar los botones 

                StartCoroutine("jugarContraEnemigoDelay");//delay antes de que el enemigo dispare           }  
            }
           
            bool haycolision = DeshabilitarFondo();//deshabilito el fondo que esta abajo de barco
            print("hay colision" + haycolision);
            instanciarFuego(this.transform.position);

            //instanciar fuego en los barcos que estan en la pantalla de arriba tanto Yo como El otro jugador
            _photonView.RPC("InstanciarFuegoEnMisBarcos", //Nombre de la función que es llamada localmente
                RpcTarget.OthersBuffered,//para obtener los parámetros o ejecutar en otros
                this.transform.position//posicion de este gameobject para usar en la posición de mis barcos en la pantalla de arriba
            );

             _BoxCollider.enabled = false;
            _GameHandlerRED.cantidadDeAciertosJugador += 1;//para saber cuando gano
            _BarcoHandler.vidas -= 1;//una vida menos

            print("TENDRIA QUE INSTANCIAR EL FUEGO");
        }

        if(_BarcoHandler.vidas < 1 && _GameHandlerRED.cantidadDeAciertosJugador < 21)//si las vidas del barco es menor a uno
        {
            sonidoBarcoEnemigoDestruido[Random.Range(0,sonidoBarcoEnemigoDestruido.Length)].GetComponent<AudioSource>().Play();//activo sonido barco destruido
            _Animator.SetBool("barcoDestruido", true);
            _GameHandlerRED.SetPuedoPresionarBoton(false);//no puedo presionar los botones
            StartCoroutine("jugarContraEnemigoDelayTargetDestroy");//delay antes de que el enemigo dispare           }  
        }

        if(_GameHandlerRED.cantidadDeAciertosJugador == 21)//si destrui todos los barcos
        {
            //destruyo última pieza del barco
            sonidoBarcoEnemigoDestruido[Random.Range(0,sonidoBarcoEnemigoDestruido.Length)].GetComponent<AudioSource>().Play();//activo sonido barco destruido
            _Animator.SetBool("barcoDestruido", true);

            _GameHandlerRED.SetPuedoPresionarBoton(false);//ya no puedo presionar la grilla
            StartCoroutine("JugadorWinner");//hago las cosas de winner
            StartCoroutine("EnemigoLosse");//hago las cosas del enemigo Losse
        }

    }


    /// <summary>hace que sea el turno del enemigo cuando acertas al disparo</summary>
    IEnumerator jugarContraEnemigoDelay()
    {
        yield return new WaitForSeconds(2f);//por defecto 2 segundos
         _GameHandlerRED.IsTurnoEnemigo();
    }

    /// <summary>hace que sea el turno del enemigo cuando destruis un barco</summary>
    IEnumerator jugarContraEnemigoDelayTargetDestroy()//hace que sea el turno del enemigo cuando destruis un barco
    {
        yield return new WaitForSeconds(4);
         _GameHandlerRED.IsTurnoEnemigo();
    }

    /// <summary>hace que termine el juego con winner para el jugador</summary>
    IEnumerator JugadorWinner()
    {  
        yield return new WaitForSeconds(2);
        _GameHandlerRED.SetPuedoPresionarBoton(false);
        musicaJugandoContraEnemigo.Stop();
        sonidoWinner.Play();//sonido winner
        yield return new WaitForSeconds(2);//despues de 2 segundos 
        _GameHandlerRED.GameOverWinner();//cambio a nivel winner
    }

    /// <summary>Le avisa al enemigo que esta muerto. El enemigo se maneja con photon</summary>
    IEnumerator EnemigoLosse()
    {
        yield return new WaitForSeconds(2);
        _photonView.RPC("GameOverRival", //Nombre de la función que es llamada localmente
                RpcTarget.OthersBuffered//ejecuto en los otros que no ganaron
            );

        yield return new WaitForSeconds(2);//despues de 2 segundos 
        _photonView.RPC("GameOverPantalla", //Nombre de la función que es llamada localmente
                RpcTarget.OthersBuffered//ejecuto en los otros que no ganaron
            );
    }

    /// <summary>Hace que no se puedan presionar los botones, desactiva la música y activa sonido GameOver</summary>
    [PunRPC]
    void GameOverRival()
    {
        _GameHandlerRED.fondoTablero.SetActive(false);
        _GameHandlerRED.animacionLuzDecoradoRoja.SetBool("isTurnEnemy",false);//luz que aparece con el tablero
        _GameHandlerRED.SetPuedoPresionarBoton(false);
        musicaJugandoContraEnemigo.Stop();
        SonidoGameOver.Play();
    }

    /// <summary>le Avisa al rival que activa pantalla gameOver</summary>
    [PunRPC]
    void GameOverPantalla()
    {
        _GameHandlerRED.GameOverLose();
    }  



    /// <summary>Para que dispare el fuego en mis barcos, osea la pantalla de arriba</summary>
    [PunRPC]
    void InstanciarFuegoEnMisBarcos(Vector3 posicionInicialFuego)
    {
        Vector3 fuegoPosicionEnEnemigo = posicionInicialFuego;
        fuegoPosicionEnEnemigo.z += 250;
        audio_hit_Own.Play();//activo sonido que dispara a mis barcos
        instanciarFuego(fuegoPosicionEnEnemigo);
        this.gameObject.GetComponent<PiezasEstadoDestruidas>().DesHabilitarParteDestruida();
    }

    /// <summary>Para que dispare el fuego en los barcos del rival, osea la pantalla de abajo</summary>
    private void instanciarFuego(Vector3 posicionInicialFuego)
    {
        GameObject fuegoInstance = Instantiate(fuego);
        //fuegoInstance.transform.SetParent(this.gameObject.transform);
        fuegoInstance.transform.position = posicionInicialFuego;
        // _BoxCollider.enabled = false;
        
    }



     public bool DeshabilitarFondo()//tengo que usar una corrutina para esperar un segundo sino se presiona el boton inmediatamente y hay un error de sincronización de botones
    {
        bool estaColisionando = false;

        if(overlappers != null)
		{
			for (int i = 0; i < overlappers.Length; i++)
			{
                BoxCollider box = overlappers[i];
                Collider[] collisions = Physics.OverlapBox(box.transform.position, box.bounds.size / 2, Quaternion.identity, isOverlapper);
                if (collisions.Length > 1)
                {
                    Debug.Log("Hay Overlap");
                    // transform.localPosition = startPos;
                    print(collisions[0].name);
                    collisions[0].GetComponent<MeshRenderer>().enabled = false;
                    collisions[0].GetComponent<BoxCollider>().enabled = false;
                    estaColisionando = true;
                    break;
                }
                else
                {
                    estaColisionando = false;
                    // puedoRotar = true;
                    Debug.Log("No hay overlap");
                }
			}
		}
        return estaColisionando;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
    }
}
