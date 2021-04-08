using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAndSFXMenuInicio : MonoBehaviour
{
    public static MusicAndSFXMenuInicio instance;
    // private HandlerDificultadEntreNiveles _HandlerDificultadEntreNiveles;//para referencia a la dificultad entre niveles

    // Start is called before the first frame update
    void Awake()
    {
        // if (MusicAndSFXMenuInicio.instance == null)
        // {
        //     MusicAndSFXMenuInicio.instance =  this;
        //     DontDestroyOnLoad(this.gameObject);//este GameObject nunca se destruye
        // }
        // else
        // {
        //     Destroy(this.gameObject);//este GameObject nunca se destruye
        // }
        // DontDestroyOnLoad(gameObject);//este GameObject nunca se destruye
        // _HandlerDificultadEntreNiveles = FindObjectOfType<HandlerDificultadEntreNiveles>();//para obtener la referencía al script

    }


    private void Start() {
        if (MusicAndSFXMenuInicio.instance == null)
        {
            MusicAndSFXMenuInicio.instance =  this;
            DontDestroyOnLoad(this.gameObject);//este GameObject nunca se destruye
        }
        else
        {
            Destroy(this.gameObject);//este GameObject nunca se destruye
        }

        // if(_HandlerDificultadEntreNiveles.nivelActual > 1)//si el nivel es mayor a uno inicio la música
        // {
        //     this.gameObject.GetComponent<AudioSource>().Play();
        // }
        // DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
