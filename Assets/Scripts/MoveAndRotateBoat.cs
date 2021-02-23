using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;

public class MoveAndRotateBoat : MonoBehaviourPun
{

    // [SerializeField] float distaciaMovimiento = 1;

    GameHandlerAcomodarPIezas _GameHandlerAcomodarPIezas;

    private void Awake() {
        _GameHandlerAcomodarPIezas = FindObjectOfType<GameHandlerAcomodarPIezas>();
       
    }

    // Start is called before the first frame update


    /// <summary>Rota 90 grados el barco</summary>
    public void RotateBoat()
    {
         transform.Rotate(new Vector3(0,0,90),Space.Self);
    }
    
    /// <summary>Mueve el barco usando la cuadricula</summary>
    public void moverBarcosPorCuadricula()
    {
        if(_GameHandlerAcomodarPIezas.GetGrilla() != null)
        {
            this.transform.position = new Vector3(
                _GameHandlerAcomodarPIezas.GetGrilla().transform.position.x,
                this.transform.position.y,
                _GameHandlerAcomodarPIezas.GetGrilla().transform.position.z
            );
           
        }
    }

}
