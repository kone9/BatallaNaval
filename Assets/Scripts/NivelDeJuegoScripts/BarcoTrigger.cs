using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarcoTrigger : MonoBehaviour
{
    public GameObject fuego;
    public BoxCollider _BoxCollider;
    
    Gamehandler _Gamehandler;
    
    private void Awake() {
        _BoxCollider = GetComponent<BoxCollider>();
        _Gamehandler = FindObjectOfType<Gamehandler>();
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
        if(_Gamehandler.GetPuedoPresionarBoton())
        {
            instanciarFuego();
            _Gamehandler.cantidadDeAciertosJugador += 1;
            print("TENDRIA QUE INSTANCIAR EL FUEGO");
        }
        if(_Gamehandler.cantidadDeAciertosJugador == 21)
        {
            _Gamehandler.GameOverWinner();
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
