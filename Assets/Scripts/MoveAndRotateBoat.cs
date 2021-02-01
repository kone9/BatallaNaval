using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndRotateBoat : MonoBehaviour
{

    // [SerializeField] float distaciaMovimiento = 1;
    private Camera mainCamera;
    private float CameraZdistance;

    GameHandlerAcomodarPIezas _GameHandlerAcomodarPIezas;

    BoxCollider _BoxCollider;

    bool puedoMover = false;

    private void Awake() {
        _GameHandlerAcomodarPIezas = FindObjectOfType<GameHandlerAcomodarPIezas>();
        _BoxCollider = this.gameObject.GetComponent<BoxCollider>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(_BoxCollider.enabled == false)
        {
            if(Input.GetMouseButtonUp(0))
            {
                _BoxCollider.enabled = true;
                puedoMover = false;
                print("tendria que aparecer el colider");
            }
        }

    }


    void GestorDeTeclas()
    {
         if(Input.GetMouseButtonUp(0))
            {
                _BoxCollider.enabled = true;
                puedoMover = false;
                print("tendria que aparecer el colider y dejar de moverse");
            }


        if(puedoMover == true)
        {
            if(Input.GetMouseButton(0))
            {
                moverBarcosPorCuadricula();
                _BoxCollider.enabled = false;

                if(Input.GetMouseButtonDown(1))
                {
                RotateBoat();
                }
            }

        }
    }


    //Para mover las piezas con el mouse
    private void OnMouseDrag()
    {
        // MoverBarcoConMouse();
       
        moverBarcosPorCuadricula();
        _BoxCollider.enabled = false;


        if(Input.GetMouseButtonDown(1))
        {
           RotateBoat();
        }
    }

    private void OnTriggerEnter(Collider other) {
        
        if(other.transform.tag == "boat")
        {
            print("entro el barco dentro de otro barco");
        }
    }

    // private void OnTriggerStay(Collider other)
    // {
    //     if(other.transform.tag == "boat")
    //     {
    //         gameObject.GetComponent<Material>().color = new Color(0.5f,1,1,1);
    //         // moverBarcosPorCuadricula();
    //         // _BoxCollider.enabled = false;


    //         // if(Input.GetMouseButtonDown(1))
    //         // {
    //         // RotateBoat();
    //         // }
    //     }
    // }


    /// <summary>Rota 90 grados el barco</summary>
    public void RotateBoat()
    {
         transform.Rotate(new Vector3(0,0,90),Space.Self);
    }
    
    /// <summary>Mueve el barco usando la cuadricula</summary>
    private void moverBarcosPorCuadricula()
    {
        if(_GameHandlerAcomodarPIezas.GetGrilla() != null)
        {
            this.transform.position = new Vector3(
                _GameHandlerAcomodarPIezas.GetGrilla().transform.position.x,
                this.transform.position.y,
                _GameHandlerAcomodarPIezas.GetGrilla().transform.position.z
            );
           ;
        }
    }

}
