using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public class CharacterVidaLuegoBorrar : MonoBehaviour, Photon.Pun.IPunObservable
{
    public int vida = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) {

        if(other.transform.tag == "Proyectil")
        {
            
            Destroy(other.gameObject);
            vida -=5;
            if(vida < 0)
            {
                Destroy(this.gameObject);
            }
        }
    }


    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)//si estoy escribiendo datos...Siempre soy yo el que escribre datos
        {
            // stream.SendNext(_GameHandlerAcomodarPIezas.GetEnemigoListo());
            stream.SendNext(vida);
        }
        else //si esta escribiendo datos un avatar
        {
            // _GameHandlerAcomodarPIezas.SetEnemigoListo((bool)stream.ReceiveNext());
            vida = (int)stream.ReceiveNext();
        }
    }
}
