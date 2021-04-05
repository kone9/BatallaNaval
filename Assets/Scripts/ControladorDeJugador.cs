using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorDeJugador : MonoBehaviour
{
    
    GameHandlerAcomodarPIezas _GameHandlerAcomodarPIezas;
    MoveAndRotateBoat _MoveAndRotateBoat;
    BoxCollider[] _BoxCollider;

    bool puedoMover = false;
    // bool waitingForOtherPlayer = true;

    AudioSource efectoBoton_2;
    AudioSource PuertaSonido;

    public Button botonAuto;//referencia al boton
    public Button BotonPlay;//referencia al boton
	// private void OnEnable()
	// {
    //     GestorDeRed.OnPlayersConnected += EnableMovement;
	// }

	// private void OnDisable()
	// {
    //     GestorDeRed.OnPlayersConnected -= EnableMovement;
    // }

	// private void EnableMovement()
	// {
    //     waitingForOtherPlayer = false;
	// }

	private void Awake()
    {
        _MoveAndRotateBoat = GetComponent<MoveAndRotateBoat>();
        _BoxCollider = this.gameObject.GetComponents<BoxCollider>();
        _GameHandlerAcomodarPIezas = FindObjectOfType<GameHandlerAcomodarPIezas>();
        efectoBoton_2 = GameObject.Find("efectoBoton_2").GetComponent<AudioSource>();
        PuertaSonido = GameObject.Find("PuertaSonido").GetComponent<AudioSource>(); 

    }

        // Update is called once per frame
    void Update()
    {

        if(puedoMover)//si puedo mover el barco llamo a las funciones para mover tengo que presionar las teclas para que se mueva
        { 
            //hay un pequeño bug con el movimiento
            StartCoroutine(MoverSoloUnaVes());

            if(Input.GetMouseButtonDown(1))//si presiono click derecho
            {
                //si esta en la grilla
                if(_GameHandlerAcomodarPIezas.inGrid(_MoveAndRotateBoat.lengthBarco,_MoveAndRotateBoat.lenghtBarcoDerecha,_MoveAndRotateBoat.lenghtBarcoIzquierda, (_MoveAndRotateBoat.direccion + 1) % 4,_MoveAndRotateBoat.X_posicion_imaginaria,_MoveAndRotateBoat.Y_posicion_imaginaria))
                {
                    //puedo rotar
                    _MoveAndRotateBoat.RotarBarco();//rotar barco
                    efectoBoton_2.Play();//efecto sonido rotar barco
                }
            }

            if(Input.GetMouseButtonUp(0))// si suelto el click izquierdo
            {
                StartCoroutine( DejarDeMover() );//verifico que no esten los barcos colisionando
            }
        }

    }



    private IEnumerator MoverSoloUnaVes()
    {
        _MoveAndRotateBoat.MoverBarcosPorCuadricula();
        yield return null;
    }

    private void OnMouseOver()//si el mouse esta arriba de la colision
    {
        Rotar_o_Mover();//puedo rotar o mover el barco al presionar click
    }


    /// <summary>Dependiendo el estado del boton que esta en la interface rota o mueve el barco al presionar click izquierdo</summary>
    private void Rotar_o_Mover()
    {
        //hay un pequeño bug con el movimiento
        if (Input.GetMouseButtonDown(0))//si presiono cEro
        {
            if (UIMovRotBtn.instance.MoveMode)//Su es verdadero el tipo de movimiento puedo mover
            {
                _MoveAndRotateBoat.startPos = transform.localPosition;
                puedoMover = true;//puedo mover
            }
            else //Sino solo puedo Rotar
            {
                if (_GameHandlerAcomodarPIezas.inGrid(_MoveAndRotateBoat.lengthBarco, _MoveAndRotateBoat.lenghtBarcoDerecha, _MoveAndRotateBoat.lenghtBarcoIzquierda, (_MoveAndRotateBoat.direccion + 1) % 4, _MoveAndRotateBoat.X_posicion_imaginaria, _MoveAndRotateBoat.Y_posicion_imaginaria))
                {
                    _MoveAndRotateBoat.RotarBarco();
                    StartCoroutine( DejarDeMover() );//si se superpone la rotación se acomoda en cualquier lugar activa sonido barco acomodado
                }
                    
            }
            efectoBoton_2.Play();//activo sonido agarre
        }
    }


    /// <summary>Verifica que no existan dos barcos colisionandose, si se colisionan se reacomodan en un lugar aleatorio</summary>
    IEnumerator DejarDeMover()//tengo que usar una corrutina para esperar un segundo sino se presiona el boton inmediatamente y hay un error de sincronización de botones
    {
        if(_MoveAndRotateBoat.EstaChocandoContraOtroBarco())
        {
            puedoMover = false;
            Coroutine tiempoEspera = StartCoroutine(_MoveAndRotateBoat.PosicionarBarcoAleatoriamenteSinColisionarConOtros());
            botonAuto.interactable = false;//no puedo tocar el boton
            BotonPlay.interactable = false;//no puedo tocar el boton
            yield return tiempoEspera;

            botonAuto.interactable = true;//no puedo tocar el boton
            BotonPlay.interactable = true;//no puedo tocar el boton
            PuertaSonido.Play();//activo sonido
            // _MoverYrotar.PosicionarBarcoAleatoriamenteSinColisionarConOtros();
        }
        else
        {
            puedoMover = false;
            PuertaSonido.Play();
        }
    }


}
