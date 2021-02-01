using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuadriculaDeColisionesJugandoNivel : MonoBehaviour
{
    Gamehandler _Gamehandler;
    
    private void Awake()
    {
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
        if(_Gamehandler.GetPuedoPresionarBoton() == true)
        {
            // print("presione en el cubo");
            this.GetComponent<MeshRenderer>().enabled = true;
            _Gamehandler.IsTurnoEnemigo();
        }

    }
}
