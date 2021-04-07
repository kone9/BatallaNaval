using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerDificultadEntreNiveles : MonoBehaviour
{
    [Header("Dificultad Settings")]
    [Tooltip("cuanto mayor es el número, menos es la posibilidad de acierto del enemigo, por lo tanto es mas facil")]
    public int dificultadPosibilidadDeAcierto = 5;//cuanto mayor es el número menos es la posibilidad de acierto

    [Header("Nivel Settings")]
    [Tooltip("cuanto mayor es el número más posibilidades de terminar el juego")]
    public int nivelActual = 1;

    public static HandlerDificultadEntreNiveles instanciaGlobalScript;

    // Start is called before the first frame update
    void Start()
    {
        NoDestruirGameObjectEntreNiveles();
        
    }

     /// <summary>Para no Destruir este Gameobject entre los niveles</summary>
    private void NoDestruirGameObjectEntreNiveles()
    {
        if (HandlerDificultadEntreNiveles.instanciaGlobalScript == null)
        {
            HandlerDificultadEntreNiveles.instanciaGlobalScript =  this;
            DontDestroyOnLoad(this.gameObject);//este GameObject nunca se destruye
        }
        else
        {
            Destroy(this.gameObject);//este GameObject nunca se destruye
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
