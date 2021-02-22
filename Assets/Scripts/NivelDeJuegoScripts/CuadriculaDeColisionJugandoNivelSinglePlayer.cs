using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuadriculaDeColisionJugandoNivelSinglePlayer : MonoBehaviour
{
    // Start is called before the first frame update
        Gamehandler _GamehandlerRED;
    
    private void Awake()
    {
        _GamehandlerRED = FindObjectOfType<Gamehandler>();
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
        if(_GamehandlerRED.GetPuedoPresionarBoton() == true)
        {
            // print("presione en el cubo");
            this.GetComponent<MeshRenderer>().enabled = true;
            _GamehandlerRED.IsTurnoEnemigo();
        }

    }
}
