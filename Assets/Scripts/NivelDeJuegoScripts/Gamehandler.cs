using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamehandler : MonoBehaviour
{
    DatosGlobales _DatosGlobales;
    GameObject[] barcos;
    GameObject[] barcosGrilla;

    public int cantidadDeAciertosJugador = 0;

    EnemigoHandler _EnemigoHandler;

    public GameObject fondoTablero;

    private bool puedoPresionarBoton = true;

    private void Awake() {
       
        _DatosGlobales = FindObjectOfType<DatosGlobales>();
        _EnemigoHandler = FindObjectOfType<EnemigoHandler>();
        barcos = GameObject.FindGameObjectsWithTag("boat");
        barcosGrilla = GameObject.FindGameObjectsWithTag("barcosGrilla");
    }
    
    // Start is called before the first frame update
    void Start()
    {
       AcomodarLosBarcos();
       AcomodarLosBarcosGrilla();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void AcomodarLosBarcos()
    {
        int indice = 0;
        foreach (GameObject i in barcos)
        {
            //acomodar posición
            i.transform.position = new Vector3(
                    _DatosGlobales.GetPosicionesBarcos()[indice].x,
                    _DatosGlobales.GetPosicionesBarcos()[indice].y,
                    _DatosGlobales.GetPosicionesBarcos()[indice].z + 250
            );
            //acomodar rotación
            i.transform.rotation = _DatosGlobales.GetRotacionBarcos()[indice];
            indice += 1;
        }
    }

    private void AcomodarLosBarcosGrilla()
    {
        int indice = 0;
        foreach (GameObject i in barcosGrilla)
        {
            //acomodar posición
            i.transform.position = _DatosGlobales.GetPosicionesBarcos()[indice];
            //acomodar rotación
            i.transform.rotation = _DatosGlobales.GetRotacionBarcos()[indice];
            indice += 1;
        }
    }

    /// <summary>Si es turno del jugador no activa el fondo de grilla<</summary>
    public void IsTurnoJugador()
    {
        fondoTablero.SetActive(false);
        puedoPresionarBoton = true;
    }

    /// <summary>Si es turno del enemigo activa el fondo de grilla</summary>
    public void IsTurnoEnemigo()
    {
        fondoTablero.SetActive(true);
        puedoPresionarBoton = false;
        _EnemigoHandler.DispararFuegoEnemigoHastaErrar();
        
    }

    /// <summary>Retorna un bolean "si puedo o no puedo" presionar Boton</summary>
    public bool GetPuedoPresionarBoton()
    {
        return this.puedoPresionarBoton;
    }

    /// <summary>Cambia al nivel GameOverWinner</summary>
    public void GameOverWinner()
    {
        SceneManager.LoadScene("YouWinner");
    }

    /// <summary>Cambia al nivel GameOverLose</summary>
    public void GameOverLose()
    {
        SceneManager.LoadScene("Youlose");
    }

}
