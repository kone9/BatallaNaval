using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoHandler : MonoBehaviour
{
    public GameObject fuego;
    public int cantidadDeAciertosEnemigo = 21;
    // private GameObject[] barcoJugadorColisiones;
    List<GameObject> barcoJugadorColisiones = new List<GameObject>();

    private Gamehandler _Gamehandler;

    //Para el audio
    AudioSource audio_hit_Own;//sonido hit
    AudioSource audio_sink_Own;//sonido hundio barco
    GameObject[] audio_miss;//sonido erro disparo

    private void Awake()
    {
        barcoJugadorColisiones.AddRange(GameObject.FindGameObjectsWithTag("barcoJugadorColisiones"));
        _Gamehandler = FindObjectOfType<Gamehandler>();
        
        audio_hit_Own = GameObject.Find("hit_Own").GetComponent<AudioSource>();
        audio_sink_Own = GameObject.Find("sink_Own").GetComponent<AudioSource>();
        audio_miss = GameObject.FindGameObjectsWithTag("miss_audio");

    }
    
    // Start is called before the first frame update
    void Start()
    {
        // for (int i = 0; i < barcoJugadorColisiones.Count; i++)
        // {
        //     print("la cantidad de barcos para destruir son" + i);
        // }
       
        // DispararFuegoConError();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>Dispara Fuegos hasta errar o mientras sea el turno del enemigo</summary>
    public void DispararFuegoEnemigoHastaErrar()
    {
        StartCoroutine("DispararFuegos");
    }



    IEnumerator  DispararFuegos()
    {
        int numeroAcierto = 1;//para representar dificultad
        int numeroAleatorio = Random.Range(0,10);//para representar dificultad
        int elementoEliminar = 0;
 
        yield return new WaitForSeconds(1);
        while(true)
        {
            //Para saber cuando es Game Over
            if(cantidadDeAciertosEnemigo < 1)
            {
                _Gamehandler.GameOverLose();
                yield return null;
            }   
            cantidadDeAciertosEnemigo -= 1;

            //Disparo al enemigo con un rango aleatorio
            if(numeroAcierto == numeroAleatorio)
            {
                int LugarAleatorio = Random.Range(0,barcoJugadorColisiones.Count);
            
                GameObject fuegoInstance = Instantiate(fuego);
                    
                //fuegoInstance.transform.SetParent(this.gameObject.transform);
                fuegoInstance.transform.position = barcoJugadorColisiones[LugarAleatorio].transform.position;
                // barcoJugadorColisiones[LugarAleatorio].GetComponent<MeshRenderer>().enabled = true;
                elementoEliminar += 1;
                barcoJugadorColisiones.RemoveAt(LugarAleatorio);
                
                
                numeroAleatorio = Random.Range(0,10);//Esto tiene que ver con la dificultad,cuanto más alto el segundo número mas fácil es jugar contra la maquina como minimo comienza con 2 para una dificultad muy alta
                print("el numero aleatorio es: "+numeroAleatorio);


                audio_hit_Own.Play();//sonido acerto al barco

                yield return new WaitForSeconds(2);//espera 2 segundos antes de volver a hacer lo mismo
            }
            else
            {
                // audio_sink_Own.Play();//sonido erro el disparo
                audio_miss[Random.Range(0,audio_miss.Length)].GetComponent<AudioSource>().Play();
                yield return new WaitForSeconds(0.4f);
                _Gamehandler.IsTurnoJugador();
                break;
            }
            
        }
    }
}
