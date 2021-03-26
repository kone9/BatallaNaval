using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ControladorDeJugador : MonoBehaviour
{
    
    GameHandlerAcomodarPIezas _GameHandlerAcomodarPIezas;
    MoveAndRotateBoat _MoveAndRotateBoat;
    BoxCollider[] _BoxCollider;

    bool puedoMover = false;
    // bool waitingForOtherPlayer = true;

    AudioSource efectoBoton_2;
    AudioSource PuertaSonido;

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

            if(Input.GetMouseButtonDown(1))
            {
                //si esta en la grilla
                if(_GameHandlerAcomodarPIezas.inGrid(_MoveAndRotateBoat.lengthBarco,_MoveAndRotateBoat.lenghtBarcoDerecha,_MoveAndRotateBoat.lenghtBarcoIzquierda, (_MoveAndRotateBoat.direccion + 1) % 4,_MoveAndRotateBoat.X_posicion_imaginaria,_MoveAndRotateBoat.Y_posicion_imaginaria))
                {
                    //puedo rotar
                    _MoveAndRotateBoat.RotarBarco();
                    efectoBoton_2.Play();
                }
            }

            if(Input.GetMouseButtonUp(0))
            {
                DejarDeMover();
                PuertaSonido.Play();
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
        // if (!waitingForOtherPlayer)
        // {
        //hay un pequeño bug con el movimiento
        if (Input.GetMouseButtonDown(0))
        {
            if (UIMovRotBtn.instance.MoveMode)
            {

                _MoveAndRotateBoat.startPos = transform.localPosition;
                puedoMover = true;//puedo mover
            }
            else
            {
                if (_GameHandlerAcomodarPIezas.inGrid(_MoveAndRotateBoat.lengthBarco, _MoveAndRotateBoat.lenghtBarcoDerecha, _MoveAndRotateBoat.lenghtBarcoIzquierda, (_MoveAndRotateBoat.direccion + 1) % 4, _MoveAndRotateBoat.X_posicion_imaginaria, _MoveAndRotateBoat.Y_posicion_imaginaria))
                    _MoveAndRotateBoat.RotarBarco();
            }
            efectoBoton_2.Play();//activo sonido agarre
        }
        // }
    }


    void DejarDeMover()//tengo que usar una corrutina para esperar un segundo sino se presiona el boton inmediatamente y hay un error de sincronización de botones
    {
        if(_MoveAndRotateBoat.EstaChocandoContraOtroBarco())
        {
            puedoMover = false;
            StartCoroutine(_MoveAndRotateBoat.PosicionarBarcoAleatoriamenteSinColisionarConOtros());
            // _MoverYrotar.PosicionarBarcoAleatoriamenteSinColisionarConOtros();
        }
        puedoMover = false;
        
        // print("Ahora tendria que dejar de moverse")
    }


}
