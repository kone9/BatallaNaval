using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuadriculaDeColisionJugandoNivelSinglePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    Gamehandler _Gamehandler;
    
    //AUDIO globales
    public GameObject[] audio_miss;//sonido errar disparo

    private MeshRenderer mymesh;
    private BoxCollider miCollyder;
    
    private void Awake()
    {
        _Gamehandler = FindObjectOfType<Gamehandler>();
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
        StartCoroutine("PresioneGrilla");

    }

    //al persionar una grilla
    IEnumerator PresioneGrilla()
    {
        if(_Gamehandler.GetPuedoPresionarBoton() == true)
        {            // print("presione en el cubo");
            mymesh.enabled = false;
            miCollyder.enabled = false;
            audio_miss[1].GetComponent<AudioSource>().Play();//activo sonido errar disparo
            _Gamehandler.SetPuedoPresionarBoton(false);
            yield return new WaitForSeconds(0.4f);
            _Gamehandler.IsTurnoEnemigo();
        }
    }
}
