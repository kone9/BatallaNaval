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

    private void Awake()
    {
        barcoJugadorColisiones.AddRange(GameObject.FindGameObjectsWithTag("barcoJugadorColisiones"));//referencia a todos los barcos guardados en una lista
        _Gamehandler = FindObjectOfType<Gamehandler>();
       

        audio_hit_Own = GameObject.Find("hit_Own").GetComponent<AudioSource>();
        audio_sink_Own = GameObject.Find("sink_Own").GetComponent<AudioSource>();
        audio_miss = GameObject.FindGameObjectsWithTag("miss_audio");

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
        StartCoroutine("destruirCastilleros");
        //StartCoroutine("DispararFuegos");//ojo este es el posta no borrar
    }

    IEnumerator destruirCastilleros()
    {
        //GRILLA
        int LugarAleatorio = GrillaJugadorColisiones.Count - 1;//el count siempre va con menos 1
        while (GrillaJugadorColisiones.Count > 0)//menos 1 porque sino no se tiene en cuenta el último índice
        {
            // int LugarAleatorio = Random.Range(0,GrillaJugadorColisiones.Count - 1);//numero eleatorio entre cantidad de grillas
            
            GrillaJugadorColisiones[LugarAleatorio].GetComponent<MeshRenderer>().enabled = false;//deshabilito la malla
            GrillaJugadorColisiones.RemoveAt(LugarAleatorio);//elimino este lugar de la grilla

            yield return new WaitForSeconds(0.1f);//por defecto es 1
            LugarAleatorio --;
        }
        print("termino de destruirse la grilla correctamente");

        yield return new WaitForSeconds(0.1f);//por defecto es 1

        //BARCOS
        LugarAleatorio = barcoJugadorColisiones.Count - 1;
        while (barcoJugadorColisiones.Count > 0)
        {
            // int LugarAleatorio = Random.Range(0,barcoJugadorColisiones.Count);

            GameObject fuegoInstance = Instantiate(fuego);

            fuegoInstance.transform.position = barcoJugadorColisiones[LugarAleatorio].transform.position;

            barcoJugadorColisiones.RemoveAt(LugarAleatorio);
            yield return new WaitForSeconds(0.2f);//por defecto es 1
            LugarAleatorio --;
        }

        print("se termino de destruir los barcos");
    }



    IEnumerator  DispararFuegos()
    {
        numeroAcierto = 1;//para representar dificultad
        numeroAleatorio = 0;//Random.Range(0,5);//Random.Range(0,5);//para representar dificultad
        // elementoEliminar = 0;
        print("el numero aleatorio es: " + numeroAleatorio);

        yield return new WaitForSeconds(0.1f);//por defecto uno
        // while(true)
        // {
            //Para saber cuando es Game Over
            // if(cantidadDeAciertosEnemigo < 1)
            // {
            //     _Gamehandler.GameOverLose();
            //     yield return null;
            // }
            // cantidadDeAciertosEnemigo -= 1;

            //Disparo al enemigo con un rango aleatorio
        if(numeroAcierto == numeroAleatorio)//entonces el enemigo dispara al jugador
        {
            int LugarAleatorio = Random.Range(0,barcoJugadorColisiones.Count);

            GameObject fuegoInstance = Instantiate(fuego);

            fuegoInstance.transform.position = barcoJugadorColisiones[LugarAleatorio].transform.position;

            // elementoEliminar += 1;
            barcoJugadorColisiones.RemoveAt(LugarAleatorio);
            print("la cantidad de posiciones de barco para destruir son: " + barcoJugadorColisiones.Count );            


            audio_hit_Own.Play();//sonido acerto al barco

            // yield return new WaitForSeconds(2);//espera 2 segundos antes de volver a hacer lo mismo
             yield return new WaitForSeconds(0.1f);//por defecto 2 segundos funciona bien
             _Gamehandler.IsTurnoJugador();
        }
        else//entonces el enemigo dispara a la grilla
        {
            int LugarAleatorio = Random.Range(0,GrillaJugadorColisiones.Count - 1);//numero eleatorio entre cantidad de grillas
            GrillaJugadorColisiones[LugarAleatorio].GetComponent<MeshRenderer>().enabled = false;//deshabilito la malla
            GrillaJugadorColisiones.RemoveAt(LugarAleatorio);//elimino este lugar de la grilla
            // audio_sink_Own.Play();//sonido erro el disparo
            audio_miss[1].GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(0.1f);//por defecto es 1
            _Gamehandler.IsTurnoJugador();
            // break;
        }
    }
}
