using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuadriculaDeColisionJugandoNivelSinglePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    Gamehandler _Gamehandler;
    
    //AUDIO globales
    public GameObject[] audio_miss;//sonido errar disparo
    
    private void Awake()
    {
        _Gamehandler = FindObjectOfType<Gamehandler>();
        audio_miss = GameObject.FindGameObjectsWithTag("miss_audio");//sonido errar disparo
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
            audio_miss[Random.Range(0,audio_miss.Length)].GetComponent<AudioSource>().Play();//activo sonido errar disparo
            _Gamehandler.IsTurnoEnemigo();
        }

    }
}
