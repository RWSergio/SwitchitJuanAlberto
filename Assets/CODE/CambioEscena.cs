using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public int collectedCoins = 0;
    [Header("Objeto al que se teletransporta de la siguiente escena")]
    public string teleportTargetObjectName; // Nombre del objeto al que quieres teletransportar en la escena de destino

    //sonido puerta//
    [Header("Sonido Puerta")]
    public AudioSource doorSound;
    [Header("Animator transición escena")]
    public Animator transicionescena;
    [Header("Guardar Valores")]
    public LevelData levelData;

    public int coin1Picked = 0, coin2Picked = 0, coin3Picked = 0;

    private void Start()
    {
        collectedCoins = 0;
        doorSound.GetComponent<AudioSource>();
    }


    public void retardoEscena()
    {
        // Carga la escena de destino
        if (SceneManager.GetActiveScene().buildIndex < 8)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene(0);

        //// Luego, busca el objeto de teletransporte en la nueva escena
        //GameObject teleportTarget = GameObject.Find(teleportTargetObjectName);

        //if (teleportTarget != null)
        //{
        //    // Teletransporta al jugador al objeto deseado en la nueva escena
        //    //other.transform.position = teleportTarget.transform.position;
        ////}
        //else
        //{
        //    Debug.LogWarning("No se encuentra el objeto");
        //}
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el objeto que toca el collider sea el jugador0
        {
            if(Time.time < levelData.bestTime)
                levelData.bestTime = Time.time;

            if(collectedCoins > levelData.collectables)
                levelData.collectables = collectedCoins;

            levelData.isComplete = true;
            ManagerGuardo.Instance.Save();
            ComandosSQLite.Instance.InsertarDatosNivel(levelData.retries, coin1Picked, coin2Picked, coin3Picked);

            Invoke("retardoEscena", 1.5f);
            transicionescena.SetTrigger("Transicion");

            doorSound.Play();
            
        }
    }
}
