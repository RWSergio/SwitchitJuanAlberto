using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [Header("Sonido")]
    [Tooltip("Sonido que va a hacer al recoger la bateria")] public AudioClip sonidoBateria;
    ScoreManager scoreManager;
    [Tooltip("Cambio Escena")] public CambioEscena cambioEscena;

    public bool coin1, coin2, coin3;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("CanvasSwitchIt 1").GetComponent<ScoreManager>();
        cambioEscena = GameObject.Find("TeleportEscena").GetComponent<CambioEscena>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cambioEscena.collectedCoins++;
            if(coin1)
                cambioEscena.coin1Picked = 1;
            if(coin2)
                cambioEscena.coin2Picked = 1;
            if(coin3)
                cambioEscena.coin3Picked = 1;
            SoundManager.Instance.EjecutarSonido(sonidoBateria);
            scoreManager.IncreaseScore();
            gameObject.SetActive(false);

        }
    }
}
