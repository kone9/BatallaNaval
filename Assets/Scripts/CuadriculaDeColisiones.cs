using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuadriculaDeColisiones : MonoBehaviour
{   
    private GameHandlerAcomodarPIezas _Gamehandler;

    private void Awake() {
        _Gamehandler = FindObjectOfType<GameHandlerAcomodarPIezas>();
    }
    private void OnMouseEnter() {
        _Gamehandler.SetGrilla(this.gameObject);
    }
    
}
