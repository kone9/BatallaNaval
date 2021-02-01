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
    private void Awake()
    {
        barcoJugadorColisiones.AddRange(GameObject.FindGameObjectsWithTag("barcoJugadorColisiones"));
        _Gamehandler = FindObjectOfType<Gamehandler>();
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
        int numeroAcierto = 1;
        int numeroAleatorio = 1;
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
                elementoEliminar += 1;
                barcoJugadorColisiones.RemoveAt(LugarAleatorio);
                
                numeroAleatorio = Random.Range(0,2);//Esto tiene que ver con la dificultad,cuanto más alto el segundo número mas fácil es jugar contra la maquina como minimo comienza con 2 para una dificultad muy alta
                print("el numero aleatorio es: "+numeroAleatorio);
                yield return new WaitForSeconds(1);
            }
            else
            {
                _Gamehandler.IsTurnoJugador();
                break;
            }
            
        }
    }
}
