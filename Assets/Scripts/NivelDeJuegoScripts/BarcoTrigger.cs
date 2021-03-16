using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarcoTrigger : MonoBehaviour
{
    public GameObject fuego;
    public BoxCollider _BoxCollider;
    
    Gamehandler _Gamehandler;

    GameObject[] sound_hit;

    public BoxCollider[] overlappers;
    public LayerMask isOverlapper;
    
    private void Awake() {
        _BoxCollider = GetComponent<BoxCollider>();
        _Gamehandler = FindObjectOfType<Gamehandler>();
        sound_hit = GameObject.FindGameObjectsWithTag("hit");
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
            // puedoDesactivarFondo = true;
            sound_hit[Random.Range(0,sound_hit.Length)].GetComponent<AudioSource>().Play();
            bool haycolision = DeshabilitarFondo();
            print("hay colision" + haycolision);
            instanciarFuego();
            _Gamehandler.cantidadDeAciertosJugador += 1;
            // sound_hit[2].GetComponent<AudioSource>().Play();

            print("TENDRIA QUE INSTANCIAR EL FUEGO");
        }
        if(_Gamehandler.cantidadDeAciertosJugador == 21)
        {
            _Gamehandler.GameOverWinner();
        }

    }   


    public bool DeshabilitarFondo()//tengo que usar una corrutina para esperar un segundo sino se presiona el boton inmediatamente y hay un error de sincronización de botones
    {
        bool estaColisionando = false;

        if(overlappers != null)
		{
			for (int i = 0; i < overlappers.Length; i++)
			{
                BoxCollider box = overlappers[i];
                Collider[] collisions = Physics.OverlapBox(box.transform.position, box.bounds.size / 2, Quaternion.identity, isOverlapper);
                if (collisions.Length > 1)
                {
                    Debug.Log("Hay Overlap");
                    // transform.localPosition = startPos;
                    print(collisions[0].name);
                    collisions[0].GetComponent<MeshRenderer>().enabled = false;
                    collisions[0].GetComponent<BoxCollider>().enabled = false;
                    estaColisionando = true;
                    break;
                }
                else
                {
                    estaColisionando = false;
                    // puedoRotar = true;
                    Debug.Log("No hay overlap");
                }
			}
		}
        return estaColisionando;
    }


    private void instanciarFuego()
    {
        GameObject fuegoInstance = Instantiate(fuego);
        //fuegoInstance.transform.SetParent(this.gameObject.transform);
        fuegoInstance.transform.position = this.transform.position;
        _BoxCollider.enabled = false;
    }


}
