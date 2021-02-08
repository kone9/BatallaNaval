using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public class DeshabilitarMultiplesScriptsEnRed : MonoBehaviourPunCallbacks
{

    MonoBehaviour[] codigos;
    // Start is called before the first frame update


    void Start()
    {
        DestruirSinoSoyYoEnRed();
    }


    /// <summary>Evita que el player mueva las naves de otro jugador en red</summary>
    void DestruirSinoSoyYoEnRed()
    {
        if(!photonView.IsMine)//sino soy yo
        {
            //Destroy(this);
            this.gameObject.SetActive(false);
            foreach (MonoBehaviour i in codigos)
            {
                i.enabled = false;
            }
        }
    }
}
