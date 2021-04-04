using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PiezasEstadoDestruidas : MonoBehaviour
{
    public Image ParteDestruida;

    /// <summary>Hace visible una imagen de fuego</summary>
    public void DesHabilitarParteDestruida()
    {
        ParteDestruida.enabled = true;
    }

    private void Awake() {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
