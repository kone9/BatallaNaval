using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using Photon.Pun;

public class GameHandlerRED : MonoBehaviourPunCallbacks,IPunObservable
{
    DatosGlobales _DatosGlobales;
    DatosGlobalesRed _DatosGlobalesRed;
    GameObject[] barcos;
    GameObject[] barcosGrilla;


    Vector3[] barcosEnemigosPosicionRed;
    Quaternion[] barcosEnemigosRotacionRed;


    public int cantidadDeAciertosJugador = 0;

    EnemigoHandler _EnemigoHandler;

    public GameObject fondoTablero;

    private bool puedoPresionarBoton = true;

    private void Awake() {
       
        _DatosGlobales = FindObjectOfType<DatosGlobales>();
        _DatosGlobalesRed = FindObjectOfType<DatosGlobalesRed>();
        _EnemigoHandler = FindObjectOfType<EnemigoHandler>();
        barcos = GameObject.FindGameObjectsWithTag("boat");
        barcosGrilla = GameObject.FindGameObjectsWithTag("barcosGrilla");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        AcomodarLosBarcos();
        StartCoroutine("cargarBarcosRivalRed");//carga las posiciones de los barcos
        
    }


    IEnumerator cargarBarcosRivalRed()
    {
        yield return new WaitForSeconds(1);
        photonView.RPC("PosicionarBarcosSegunSeaJugadorOEnemigo",RpcTarget.All,_DatosGlobalesRed.SoyJugador);
        yield return new WaitForSeconds(2);
        
        AcomodarLosBarcosGrilla(barcosEnemigosPosicionRed);
        
        foreach (Vector3 i in barcosEnemigosPosicionRed)
        {
            print(i);
        }
        //print(barcosEnemigosRed);
    }


    [PunRPC]
    //hace que los barcos se posiciones segun sea el jugador o el rival.
    //si es el jugador se posiciona en la parte de arriba
    //si es el enemigo se posiciona en la parte de abajo.
    void PosicionarBarcosSegunSeaJugadorOEnemigo(bool isMine)
    {
        if(isMine)
        {
            barcosEnemigosPosicionRed = _DatosGlobales.GetPosicionesBarcos();
            barcosEnemigosRotacionRed = _DatosGlobales.GetRotacionBarcos();
        }
        if(!isMine)
        {
            barcosEnemigosPosicionRed = _DatosGlobales.GetPosicionesBarcos();
            barcosEnemigosRotacionRed = _DatosGlobales.GetRotacionBarcos();
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AcomodarLosBarcos()//acomoda los barcos que estan en la pantalla de arriba
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

    private void AcomodarLosBarcosGrilla(Vector3[] posiciones)//acomoda los abrcos de la pantalla grande son los de los enemigos
    {
        int indice = 0;
        foreach (GameObject i in barcosGrilla)
        {
            //acomodar posición
            i.transform.position = posiciones[indice];
            //acomodar rotación
            i.transform.rotation = barcosEnemigosRotacionRed[indice];
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

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
         if(stream.IsWriting)//si estoy escribiendo datos...Siempre soy yo el que escribre datos
        {

            stream.SendNext(barcosEnemigosPosicionRed);
        }
        else //si esta escribiendo datos un avatar
        {
            barcosEnemigosPosicionRed = (Vector3[])stream.ReceiveNext();

        }
    }
}
