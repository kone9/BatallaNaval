using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;
using Photon.Realtime;

public class SoyJugadorOEnemigo : MonoBehaviour
{
    //ESTO ES TESTING
    public Text infoText;
    private PhotonView infoPhoton;
    // Start is called before the first frame update
    void Start()
    {
        infoPhoton = GetComponent<PhotonView>();
        StartCoroutine("VerificarSiSoyJugadorOenemigo");
    }
    IEnumerator VerificarSiSoyJugadorOenemigo()
    {
        yield return new WaitForSeconds(3.0f);
        if(infoPhoton.IsMine)
        {
            infoText.text = "SOY JUGADOR";
        }
        if(!infoPhoton.IsMine)
        {
            infoText.text = "SOY ENEMIGO";
        }
    }
    
}
