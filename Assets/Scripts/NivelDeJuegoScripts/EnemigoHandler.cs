using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoHandler : MonoBehaviour
{
    public GameObject fuego;
    public int cantidadDeAciertosEnemigo;
    // private GameObject[] barcoJugadorColisiones;
    List<GameObject> barcoJugadorColisiones = new List<GameObject>();//listo de los barcos
    List<GameObject> GrillaJugadorColisiones = new List<GameObject>();//lista de la grilla
    public int cantidadDeGrillas;
    private Gamehandler _Gamehandler;

    int numeroAcierto, numeroAleatorio, elementoEliminar;//para representar dificultad

    //Para el audio
    AudioSource audio_hit_Own;//sonido hit
    AudioSource audio_sink_Own;//sonido hundio barco
    GameObject[] audio_miss;//sonido erro disparo

    AudioSource musicaJugandoContraEnemigo;
    AudioSource sonidoGameOver;

    private void Awake()
    {
        barcoJugadorColisiones.AddRange(GameObject.FindGameObjectsWithTag("barcoJugadorColisiones"));//referencia a todos los barcos guardados en una lista
        _Gamehandler = FindObjectOfType<Gamehandler>();
       

        audio_hit_Own = GameObject.Find("hit_Own").GetComponent<AudioSource>();
        audio_sink_Own = GameObject.Find("sink_Own").GetComponent<AudioSource>();
        audio_miss = GameObject.FindGameObjectsWithTag("miss_audio");
        musicaJugandoContraEnemigo = GameObject.Find("MusicaJugandoContraEnemigo").GetComponent<AudioSource>();
        sonidoGameOver = GameObject.Find("SonidoGameOver").GetComponent<AudioSource>();

        StartCoroutine("BuscarCuadriculaColisionJugador");//Busca las cuadriculas despues de un tiempo ya que deshabilito algunos

    }

    /// <summary>Busca las cuadriculas despues de un tiempo ya que deshabilito algunos</summary>
     IEnumerator BuscarCuadriculaColisionJugador()
    {
        yield return new WaitForSeconds(2f);
        GrillaJugadorColisiones.AddRange(GameObject.FindGameObjectsWithTag("CuadriculaColisionJugador"));//referencia a toda la grilla guardados en una lista
        cantidadDeGrillas = GrillaJugadorColisiones.Count;
        // foreach (GameObject i in GrillaJugadorColisiones)
        // {
        //     print(i.name);
        // }
        // verifica si hay algún gameobject vacio
        // for (var i = 0; i < GrillaJugadorColisiones.Count; i++)
        // {
        //     if(!GrillaJugadorColisiones[i].activeInHierarchy)//si hay alguno vacio
        //     {
        //         print("hay un gameobject destruido");
        //         GrillaJugadorColisiones.RemoveAt(i);//remuevo de la lista
        //     }
        // }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        cantidadDeAciertosEnemigo = barcoJugadorColisiones.Count;//ejo siempre es uno menos por indice cero
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>Dispara Fuegos hasta errar o mientras sea el turno del enemigo</summary>
    public void DispararFuegoEnemigoHastaErrar()
    {
        //
        // StartCoroutine("destruirCastilleros");//para hacer pruebas
        StartCoroutine("GameHandlerDisparar");//ojo este es el posta no borrar
    }

    IEnumerator TESTINGFUEGOYGRILLADETECTED()//herramienta para testing del enemigo
    {
        //GRILLA
        // int LugarAleatorio = GrillaJugadorColisiones.Count - 1;//el count siempre va con menos 1
        while (GrillaJugadorColisiones.Count > 0)//menos 1 porque sino no se tiene en cuenta el último índice
        {
            int LugarAleatorio = Random.Range(0,GrillaJugadorColisiones.Count - 1);//numero eleatorio entre cantidad de grillas
            
            GrillaJugadorColisiones[LugarAleatorio].GetComponent<MeshRenderer>().enabled = false;//deshabilito la malla
            GrillaJugadorColisiones.RemoveAt(LugarAleatorio);//elimino este lugar de la grilla

            yield return new WaitForSeconds(0.1f);//por defecto es 1
            LugarAleatorio --;
        }
        print("termino de destruirse la grilla correctamente");

        yield return new WaitForSeconds(0.1f);//por defecto es 1

        //BARCOS
        // LugarAleatorio = barcoJugadorColisiones.Count - 1;
        while (barcoJugadorColisiones.Count > 0)
        {
            int LugarAleatorio = Random.Range(0,barcoJugadorColisiones.Count);

            GameObject fuegoInstance = Instantiate(fuego);

            fuegoInstance.transform.position = barcoJugadorColisiones[LugarAleatorio].transform.position;

            barcoJugadorColisiones.RemoveAt(LugarAleatorio);
            yield return new WaitForSeconds(0.2f);//por defecto es 1
            LugarAleatorio --;
        }

        print("se termino de destruir los barcos");
    }


    /// <summary>Hace la comprobación para saber si disparar a grilla o barco</summary>
    IEnumerator GameHandlerDisparar()
    {
        numeroAcierto = 1;//para representar dificultad
        // numeroAleatorio = Random.Range(0,5);//1;//Random.Range(0,5);//para representar dificultad
        numeroAleatorio = 1;

        yield return new WaitForSeconds(1f);//por defecto uno

        //Disparo al enemigo con un rango aleatorio
        if(numeroAcierto == numeroAleatorio)//entonces el enemigo dispara al jugador
        {
           StartCoroutine("DispararFuegoAJugador");
        }
        else//entonces el enemigo dispara a la grilla
        {
            StartCoroutine("SeleccionarGrillaAleatoria");
        }
    }

    /// <summary>Dispara fuego a barco hasta que sea gameOver</summary>
    IEnumerator DispararFuegoAJugador()
    {
        if(barcoJugadorColisiones.Count > 1)//si hay colisiones
        {
            InstanciarFuego();
            // yield return new WaitForSeconds(2);//espera 2 segundos antes de volver a hacer lo mismo
            yield return new WaitForSeconds(2f);//por defecto 2 segundos funciona bien
            _Gamehandler.IsTurnoJugador();
        }
        else //sino es GameOver ya que gana el enemigo
        {
            InstanciarFuego();
            yield return new WaitForSeconds(1);
            _Gamehandler.SetPuedoPresionarBoton(false);
            musicaJugandoContraEnemigo.Stop();
            sonidoGameOver.Play();//sonido winner
            yield return new WaitForSeconds(2);//despues de 2 segundos 
            _Gamehandler.fondoTablero.SetActive(false);
            _Gamehandler.GameOverLose();//es game
        }
    }

    /// <summary>Selecciona una grilla de forma aleatoria y la destruye</summary>
    IEnumerator SeleccionarGrillaAleatoria()
    {
        if(GrillaJugadorColisiones.Count > 0)//si todavía hay grilla para disparar
        {
            int LugarAleatorio = Random.Range(0,GrillaJugadorColisiones.Count);//numero eleatorio entre cantidad de grillas
            GrillaJugadorColisiones[LugarAleatorio].GetComponent<MeshRenderer>().enabled = false;//deshabilito la malla
            GrillaJugadorColisiones.RemoveAt(LugarAleatorio);//elimino este lugar de la grilla
            
            audio_miss[1].GetComponent<AudioSource>().Play();

            yield return new WaitForSeconds(1f);//por defecto es 1
            _Gamehandler.IsTurnoJugador();//es turno de jugador
        }
        else//sino solo va a disparar fuego hasta terminar el juego
        {
            StartCoroutine("DispararFuegoAJugador");
        }
    }

    /// <summary>Instancia el fuego a la escena en una cuadricula</summary>
    void InstanciarFuego()
    {
        int LugarAleatorio = Random.Range(0,barcoJugadorColisiones.Count);//el ultimo numero no se incluye asi que es correcto

        GameObject fuegoInstance = Instantiate(fuego);

        fuegoInstance.transform.position = barcoJugadorColisiones[LugarAleatorio].transform.position;
        barcoJugadorColisiones[LugarAleatorio].GetComponent<PiezasEstadoDestruidas>().DesHabilitarParteDestruida();

        // elementoEliminar += 1;
        barcoJugadorColisiones.RemoveAt(LugarAleatorio);
        // print("la cantidad de posiciones de barco para destruir son: " + barcoJugadorColisiones.Count );            

        audio_hit_Own.Play();//sonido acerto al barco
    }


}
