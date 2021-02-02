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

    BoxCollider[] _BoxCollider;

    bool puedoMover = false;

    private void Awake() {
        _GameHandlerAcomodarPIezas = FindObjectOfType<GameHandlerAcomodarPIezas>();
        _BoxCollider = this.gameObject.GetComponents<BoxCollider>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(puedoMover)//si puedo mover el barco llamo a las funciones para mover tengo que presionar las teclas para que se mueva
        {
            print("tendria que moverse");
            moverBarcosPorCuadricula();

            if(Input.GetMouseButtonDown(1))
            {
                RotateBoat();
            }
            StartCoroutine("DejarDeMover");//para dejar de mover y evitar que las teclas se superpongan con una corrutina
        }

    }


    void GestorDeTeclas()
    {
         if(Input.GetMouseButtonUp(0))
            {
                foreach (Collider i in _BoxCollider)
                {
                    i.enabled = true;
                }
                puedoMover = false;
                print("tendria que aparecer el colider y dejar de moverse");
            }


        if(puedoMover == true)
        {
            if(Input.GetMouseButton(0))
            {
                moverBarcosPorCuadricula();
                foreach (Collider i in _BoxCollider)
                {
                    i.enabled = false;
                }
                if(Input.GetMouseButtonDown(1))
                {
                RotateBoat();
                }
            }

        }
    }


    private void OnMouseOver()
    {  
        Mover();
    }


    private void Mover()
    {
        if(Input.GetMouseButtonDown(0) && !puedoMover)
        {
            puedoMover = true;
            foreach (Collider i in _BoxCollider)
            {
                i.enabled = false;
            }
        }
    }


    IEnumerator DejarDeMover()//tengo que usar una corrutina para esperar un segundo sino se presiona el boton inmediatamente y hay un error de sincronización de botones
    {
        yield return new WaitForSeconds(1.0f);
        if(Input.GetMouseButtonDown(0) && puedoMover == true)
            {
                puedoMover = false;
                foreach (Collider i in _BoxCollider)
                {
                    i.enabled = true;
                }
                print("Ahora tendria que dejar de moverse");
            }
    }

    

    private void OnTriggerEnter(Collider other) {
        
        if(other.transform.tag == "boat")
        {
            print("entro el barco dentro de otro barco");
            
        }
    }



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
