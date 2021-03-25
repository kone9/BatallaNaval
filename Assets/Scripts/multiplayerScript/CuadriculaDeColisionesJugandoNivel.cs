using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuadriculaDeColisionesJugandoNivel : MonoBehaviour
{
    GameHandlerRED _GamehandlerRED;

     //AUDIO globales
    public GameObject[] audio_miss;//sonido errar disparo

    private MeshRenderer mymesh;
    private BoxCollider miCollyder;

    
    private void Awake()
    {
        _GamehandlerRED = FindObjectOfType<GameHandlerRED>();
        audio_miss = GameObject.FindGameObjectsWithTag("miss_audio");//sonido errar disparo
        mymesh = GetComponent<MeshRenderer>();
        miCollyder = GetComponent<BoxCollider>();
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
        if(_GamehandlerRED.GetPuedoPresionarBoton())//si puedo presionar boton
        {
            StartCoroutine("PresioneGrilla");
        }
    }

    /// <summary>Desactivo todo lo relacionado a la cuadricula y activa turno enemigo</summary>
    IEnumerator PresioneGrilla()
    {
        mymesh.enabled = false;
        miCollyder.enabled = false;
        audio_miss[1].GetComponent<AudioSource>().Play();//activo sonido errar disparo
        _GamehandlerRED.SetPuedoPresionarBoton(false);
        yield return new WaitForSeconds(0.4f);
        _GamehandlerRED.IsTurnoEnemigo();

    }
}
