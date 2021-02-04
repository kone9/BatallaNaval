using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public class ControladorDeJugador : MonoBehaviourPunCallbacks
{
    

    MoveAndRotateBoat _MoveAndRotateBoat;
    BoxCollider[] _BoxCollider;

    bool puedoMover = false;

    private void Awake()
    {
        _MoveAndRotateBoat = GetComponent<MoveAndRotateBoat>();
        _BoxCollider = this.gameObject.GetComponents<BoxCollider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //DestruirSinoSoyYoEnRed();
    }

    /// <summary>Evita que el player mueva las naves de otro jugador en red</summary>
    void DestruirSinoSoyYoEnRed()
    {
        if(!photonView.IsMine)//sino soy yo
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(puedoMover)//si puedo mover el barco llamo a las funciones para mover tengo que presionar las teclas para que se mueva
        {
            print("tendria que moverse");
            _MoveAndRotateBoat.moverBarcosPorCuadricula();

            if(Input.GetMouseButtonDown(1))
            {
                _MoveAndRotateBoat.RotateBoat();
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
                _MoveAndRotateBoat.moverBarcosPorCuadricula();
                foreach (Collider i in _BoxCollider)
                {
                    i.enabled = false;
                }
                if(Input.GetMouseButtonDown(1))
                {
                _MoveAndRotateBoat.RotateBoat();
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


}
