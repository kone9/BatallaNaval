using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarcoTriggerRed : MonoBehaviour
{
     public GameObject fuego;
    public BoxCollider _BoxCollider;
    
    GameHandlerRED _GameHandlerRED;
    
    private void Awake() {
        _BoxCollider = GetComponent<BoxCollider>();
        _GameHandlerRED = FindObjectOfType<GameHandlerRED>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnMouseDown() 
    { 
        if(_GameHandlerRED.GetPuedoPresionarBoton())
        {
            instanciarFuego();
            _GameHandlerRED.cantidadDeAciertosJugador += 1;
            print("TENDRIA QUE INSTANCIAR EL FUEGO");
        }
        if(_GameHandlerRED.cantidadDeAciertosJugador == 21)
        {
            _GameHandlerRED.GameOverWinner();
        }

    }   

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "cuadriculaColision")
        {
            other.gameObject.SetActive(false);
            // print("la grilla colisiono con un barco");
        }
    }


    private void instanciarFuego()
    {
        GameObject fuegoInstance = Instantiate(fuego);
        //fuegoInstance.transform.SetParent(this.gameObject.transform);
        fuegoInstance.transform.position = this.transform.position;
        _BoxCollider.enabled = false;
    }
}
