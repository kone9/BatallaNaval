using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarcoHandler : MonoBehaviour  //ojo hago referencía a casi todo desde los triggers de los barcos

{

    public int vidas = 2;

    private Animator _Animator;

    private void Awake()
    {
        _Animator = GetComponent<Animator>();
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
