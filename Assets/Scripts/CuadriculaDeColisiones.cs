using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuadriculaDeColisiones : MonoBehaviour
{   

    public int Grilla_X_posicion = 0;
    public int Grilla_Y_posicion = 0;
    private GameHandlerAcomodarPIezas _Gamehandler;

    private void Awake() {
        _Gamehandler = FindObjectOfType<GameHandlerAcomodarPIezas>();
    }
    private void OnMouseEnter()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;//activo la malla de vista
        // _Gamehandler.SetGrilla(this.gameObject);
    }

    private void OnMouseExit()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;//desactivo la malla de vista
    }
    // // private void OnTriggerEnter(Collider other) {
    // //     // if(other.transform.tag == "boat")
    // //     // {
    // //     //     this.gameObject.SetActive(false);
    // //     // }
    // //     if(other.transform.tag == "bordeDebarco" && other.transform.tag == "boat")
    // //     {
    // //         this.gameObject.SetActive(false);
    // //     }
    // // }
    
}
