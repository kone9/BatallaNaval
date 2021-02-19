using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuadriculaDeColisionesJugandoNivel : MonoBehaviour
{
    GameHandlerRED _GamehandlerRED;
    
    private void Awake()
    {
        _GamehandlerRED = FindObjectOfType<GameHandlerRED>();
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
