using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAndSFXMenuInicio : MonoBehaviour
{
    public static MusicAndSFXMenuInicio instance;

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
        // DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
