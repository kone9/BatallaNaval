using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixearCamara : MonoBehaviour
{
    public Transform target;
    Camera camaraActual;

    float defaultwidth;

    bool mainteneWidth = true;

    private void Awake() {
        camaraActual = GetComponent<Camera>();
        defaultwidth = camaraActual.transform.position.y * Screen.width;
    }
    void Update()
    {
        if(mainteneWidth)
        {
            camaraActual.transform.position = new Vector3(
                this.transform.position.x,
                defaultwidth / Screen.width,
                this.transform.position.z
            ); 
                
        }
        else
        {

        }
        // Vector3 screenPos = cam.WorldToScreenPoint(target.position);
        // cam.transform.position = this.transform.position - screenPos;
        // Debug.Log("target is " + screenPos.x + " pixels from the left");
        // Vector3 pos = new Vector3(15, Screen.height - 15, 10);
        // transform.position = Camera.main.ScreenToWorldPoint(pos);
        // float posicionAnterior  = Screen.width;
        // float diferencia = posicionAnterior + Screen.width;
        // camaraActual.aspect = Screen.width;
        // print("el tamaño de la pantalla en height: "  + diferencia);
    }
}
