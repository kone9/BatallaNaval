using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoHandler : MonoBehaviour
{
    public GameObject fuego; //para instanciar fuego
    public int cantidadDeAciertosEnemigo;
    // private GameObject[] barcoJugadorColisiones;
    List<GameObject> barcoJugadorColisiones = new List<GameObject>();//listo de los barcos
    List<GameObject> GrillaJugadorColisiones = new List<GameObject>();//lista de la grilla
    public int cantidadDeGrillas;
    private Gamehandler _Gamehandler;

    int numeroAcierto, numeroAleatorio, elementoEliminar;//para representar dificultad

    //Para el audio
    GameObject[] audio_hit_Own;//sonido hit
    AudioSource audio_hit_Own_end;//sonido hit
    GameObject[] miss_enemy;//sonido erro disparo

    AudioSource musicaJugandoContraEnemigo;
    AudioSource sonidoGameOver;

    private HandlerDificultadEntreNiveles _HandlerDificultadEntreNiveles;//para referencia a la dificultad entre niveles

    private void Awake()
    {
        barcoJugadorColisiones.AddRange(GameObject.FindGameObjectsWithTag("barcoJugadorColisiones"));//referencia a todos los barcos guardados en una lista
        _Gamehandler = FindObjectOfType<Gamehandler>();
       

        audio_hit_Own = GameObject.FindGameObjectsWithTag("hit_Own");
        audio_hit_Own_end = GameObject.Find("sink_Own_end").GetComponent<AudioSource>();
        miss_enemy = GameObject.FindGameObjectsWithTag("miss_1_enemy");
        musicaJugandoContraEnemigo = GameObject.Find("MusicaJugandoContraEnemigo").GetComponent<AudioSource>();
        sonidoGameOver = GameObject.Find("SonidoGameOver").GetComponent<AudioSource>();

        _HandlerDificultadEntreNiveles = FindObjectOfType<HandlerDificultadEntreNiveles>();//para obtener la referencía al script

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
        numeroAleatorio = Random.Range(0,_HandlerDificultadEntreNiveles.dificultadPosibilidadDeAcierto);//1;//Random.Range(0,5);//para representar dificultad
        // numeroAleatorio = 1; //numero aleatorio para hacer pruebas de disparo

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
            audio_hit_Own[Random.Range(0,audio_hit_Own.Length)].GetComponent<AudioSource>().Play();//sonido acerto al barco
            StartCoroutine(_Gamehandler.Mensaje_bardeadaEnemigoAcertarDisparo());
            // yield return new WaitForSeconds(2);//espera 2 segundos antes de volver a hacer lo mismo
            yield return new WaitForSeconds(2f);//por defecto 2 segundos funciona bien
            _Gamehandler.IsTurnoJugador();
        }
        else //sino es GameOver ya que gana el enemigo
        {
            InstanciarFuego();
            audio_hit_Own_end.Play();//sonido final termino la partida al ganar
            yield return new WaitForSeconds(1);
            _Gamehandler.SetPuedoPresionarBoton(false);
            musicaJugandoContraEnemigo.Stop();
            sonidoGameOver.Play();//sonido winner
            yield return new WaitForSeconds(2);//despues de 2 segundos 
            _Gamehandler.fondoTablero.SetActive(false);
            _Gamehandler.GameOverLose();//es game
            //cambia al proximo nivel o muestra que es GameOVer

        }
    }

    /// <summary>Selecciona una grilla de forma aleatoria y la destruye</summary>
    IEnumerator SeleccionarGrillaAleatoria()
    {
        if(GrillaJugadorColisiones.Count > 0)//si todavía hay grilla para disparar
        {
            StartCoroutine(_Gamehandler.Mensaje_bardeadaEnemigoErrarDisparo());
            int LugarAleatorio = Random.Range(0,GrillaJugadorColisiones.Count);//numero eleatorio entre cantidad de grillas
            GrillaJugadorColisiones[LugarAleatorio].GetComponent<MeshRenderer>().enabled = false;//deshabilito la malla
            GrillaJugadorColisiones.RemoveAt(LugarAleatorio);//elimino este lugar de la grilla
            
            miss_enemy[Random.Range(0,miss_enemy.Length)].GetComponent<AudioSource>().Play();

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
    }


}
