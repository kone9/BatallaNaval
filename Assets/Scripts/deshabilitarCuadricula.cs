using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deshabilitarCuadricula : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)//si algo entra
    {
        if(other.CompareTag("barcoJugadorColisiones"))//si tiene este tag
        {
            // this.gameObject.SetActive(false);//deshabilito el suelo
            Destroy(this.gameObject);
        }

    }
}
