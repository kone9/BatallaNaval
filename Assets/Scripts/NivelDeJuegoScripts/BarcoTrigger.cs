using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarcoTrigger : MonoBehaviour
{
    public GameObject fuego;
    public BoxCollider _BoxCollider;
    
    Gamehandler _Gamehandler;

    GameObject[] sound_hit;

    public BoxCollider[] overlappers;
    public LayerMask isOverlapper;

    BarcoHandler _BarcoHandler;
    Animator _Animator;

    AudioSource sonidoWinner;

    GameObject[] sonidoBarcoEnemigoDestruido;
    AudioSource musicaJugandoContraEnemigo;

    private HandlerDificultadEntreNiveles _HandlerDificultadEntreNiveles;//para referencia a la dificultad entre niveles

    
    private void Awake() {
        _BoxCollider = GetComponent<BoxCollider>();
        _Gamehandler = FindObjectOfType<Gamehandler>();
        _HandlerDificultadEntreNiveles = FindObjectOfType<HandlerDificultadEntreNiveles>();//para obtener la referencía al script


        _BarcoHandler = transform.parent.GetComponent<BarcoHandler>();
        _Animator = transform.parent.GetComponent<Animator>();
        
        sound_hit = GameObject.FindGameObjectsWithTag("hit");
        sonidoWinner = GameObject.Find("SonidoWinner").GetComponent<AudioSource>();
        sonidoBarcoEnemigoDestruido = GameObject.FindGameObjectsWithTag("SonidoBarcoEnemigoDestruido");//referencia a la sonido barcos destruidos
        musicaJugandoContraEnemigo = GameObject.Find("MusicaJugandoContraEnemigo").GetComponent<AudioSource>();//referencia a la música del juego
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnMouseDown()//si el mouse presiona el area 
    { 
        Diparar();//disparo contra el barco
    }

    /// <summary>Disparo contra los barcos y hago todo lo referenciado a disparar</summary>
    void Diparar()
    {
        if(_Gamehandler.GetPuedoPresionarBoton())//si puedo presionar boton
        {
            // puedoDesactivarFondo = true;
            if(_BarcoHandler.vidas > 1 && _Gamehandler.cantidadDeAciertosJugador < 21)//si vidas de barco es mayor a uno
            {
                sound_hit[Random.Range(0,sound_hit.Length)].GetComponent<AudioSource>().Play();
                _Gamehandler.SetPuedoPresionarBoton(false);//no puedo presionar los botones
                StartCoroutine("jugarContraEnemigoDelay");//delay antes de que el enemigo dispare           }  
            }
            bool haycolision = DeshabilitarFondo();//deshabilito el fondo que esta abajo de barco
            print("hay colision" + haycolision);
            instanciarFuego();
            _Gamehandler.cantidadDeAciertosJugador += 1;//para saber cuando gano
            _BarcoHandler.vidas -= 1;//una vida menos
            // sound_hit[2].GetComponent<AudioSource>().Play();

            print("TENDRIA QUE INSTANCIAR EL FUEGO");
        }

        if(_BarcoHandler.vidas < 1 && _Gamehandler.cantidadDeAciertosJugador < 21)//si las vidas del barco es menor a uno
        {
            sonidoBarcoEnemigoDestruido[Random.Range(0,sonidoBarcoEnemigoDestruido.Length)].GetComponent<AudioSource>().Play();//activo sonido barco destruido
            _Animator.SetBool("barcoDestruido", true);
            _Gamehandler.SetPuedoPresionarBoton(false);//no puedo presionar los botones
            StartCoroutine("jugarContraEnemigoDelayTargetDestroy");//delay antes de que el enemigo dispare           }  
        }

        if(_Gamehandler.cantidadDeAciertosJugador == 21)//si destrui todos los barcos
        {
            //destruyo última pieza del barco
            sonidoBarcoEnemigoDestruido[Random.Range(0,sonidoBarcoEnemigoDestruido.Length)].GetComponent<AudioSource>().Play();//activo sonido barco destruido
            _Animator.SetBool("barcoDestruido", true);

            //verifico si cambio de nivel o muestro la pantalla WinnerGameOver
            if (_HandlerDificultadEntreNiveles.nivelActual <= 3)
            {
                _Gamehandler.SetPuedoPresionarBoton(false);//ya no puedo presionar la grilla
                 StartCoroutine("PasarAlSiguienteNivelWinner");//hago las cosas de winner
            }
            else
            {
                _Gamehandler.SetPuedoPresionarBoton(false);//ya no puedo presionar la grilla
                 StartCoroutine("JugadorWinner");//hago las cosas de winner
            }
           
        }

    }

     /// <summary>hace que sea el turno del enemigo cuando acertas al disparo</summary>
    IEnumerator jugarContraEnemigoDelay()
    {
        yield return new WaitForSeconds(2f);//por defecto 2 segundos
         _Gamehandler.IsTurnoEnemigo();
    }
    
    /// <summary>hace que sea el turno del enemigo cuando destruis un barco</summary>
    IEnumerator jugarContraEnemigoDelayTargetDestroy()//hace que sea el turno del enemigo cuando destruis un barco
    {
        yield return new WaitForSeconds(4);
         _Gamehandler.IsTurnoEnemigo();
    }

    /// <summary>Hace que aparescan las cosas cuando el jugador gana</summary>
    IEnumerator JugadorWinner()
    {  
        yield return new WaitForSeconds(2);
        musicaJugandoContraEnemigo.Stop();
        sonidoWinner.Play();//sonido winner
        yield return new WaitForSeconds(2);//despues de 2 segundos 
        _Gamehandler.GameOverWinner();//cambio a nivel winner
    }

    IEnumerator PasarAlSiguienteNivelWinner()
    {  
        yield return new WaitForSeconds(2);//espero 2 segundos
        musicaJugandoContraEnemigo.Stop();//detengo la música
        sonidoWinner.Play();//sonido winner
        _Gamehandler.UI_CambiarNivel.SetActive(true);//activo fondo
        yield return new WaitForSeconds(5);//despues de 5 segundos 
        _Gamehandler.CambiarAlProximoNivel();//cambio a nivel winner
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


    private void instanciarFuego()
    {
        GameObject fuegoInstance = Instantiate(fuego);
        //fuegoInstance.transform.SetParent(this.gameObject.transform);
        fuegoInstance.transform.position = this.transform.position;
        _BoxCollider.enabled = false;
    }


}
