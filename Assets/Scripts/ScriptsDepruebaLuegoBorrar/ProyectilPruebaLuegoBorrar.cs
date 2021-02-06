using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilPruebaLuegoBorrar : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody proyectil;
    public int velocidadProyectil = 500;
    private void Awake() {
        proyectil = GetComponent<Rigidbody>();
       
    }
    void Start()
    {
        Destroy(this.gameObject,1.5f);
    }

    // Update is called once per frame
    private void FixedUpdate() {
        proyectil.velocity = this.transform.forward * velocidadProyectil * Time.fixedDeltaTime;
    }

}
