using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonAuto : MonoBehaviour
{
    GameObject[] barcos;
    GameObject[] cuadriculas;

    GameHandlerAcomodarPIezas _GameHandler;
    AudioSource efectoBoton_2;

    public Button play;//referencia al boton



    private void Awake()
    {
        barcos = GameObject.FindGameObjectsWithTag("boat");//busca todos los barcos
        cuadriculas = GameObject.FindGameObjectsWithTag("cuadriculaColision");
        _GameHandler = FindObjectOfType<GameHandlerAcomodarPIezas>();
        efectoBoton_2 = GameObject.Find("efectoBoton_2").GetComponent<AudioSource>();
        // listaDeNumeros = new int[cantidadNumerosAletorios];
    }

    public void AutoBoton()
    {
        efectoBoton_2.Play();
        StartCoroutine("PosicionarBarcoAleatoriamente");
    
        // PosicionarBarcoAleatoriamente();
    }

    // // prueba posicionar el barco mientras no este afuera
    public IEnumerator PosicionarBarcoAleatoriamente()
    {
        this.GetComponent<Button>().interactable = false;//no puedo tocar el boton
        play.interactable = false;//deshabilita el boton
        
        for (int i = 0; i < 5; i++)//Solo funciona hasta 3 tengo..No funciona portaAviones, ni submarino
        {
            GameObject barcoActual = barcos[i];

            StartCoroutine(barcoActual.GetComponent<MoveAndRotateBoat>().PosicionarBarcoAleatoriamenteSinColisionarConOtros());    
        }
        
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<Button>().interactable = true;//puedo volver a tocar el boton
        play.interactable = true;//habilita el boton
    }
}
