using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

/// <summary>Evita que el jugador manipule los jugadores rivales</summary>
public class DeshabilitarSinoSoyYoScriptsEnRed : MonoBehaviourPunCallbacks
{

    public MonoBehaviour[] codigos;
    private PhotonView gestorPhoton;

    private void Awake() {
        gestorPhoton = GetComponent<PhotonView>();
    }
    // Start is called before the first frame update


    void Start()
    {
        // DestruirSinoSoyYoEnRed();
    }


    /// <summary>Evita que el player mueva las naves de otro jugador en red</summary>
    void DestruirSinoSoyYoEnRed()
    {
        if(!gestorPhoton.IsMine)//sino soy yo
        {
            //Destroy(this);
            //this.gameObject.SetActive(false);
            foreach (MonoBehaviour i in codigos)
            {
                i.enabled = false;
            }
        }
    }
}
