using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Este script es para la muerte del jugador
/// </summary>
public class Muerte : MonoBehaviour
{
    public float tiempoReinicio = 1.0f;
    public GameObject particulasMuerte;

    //sonidos//
    public AudioSource deathSound;
    private void Start()
    {
        deathSound.GetComponent<AudioSource>();
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            deathSound.Play();
            ManagerGuardo.Instance.levelData.retries++;
            Instantiate(particulasMuerte, transform.position, transform.rotation);
            gameObject.SetActive(false);
            Invoke("ReiniciarEscena", tiempoReinicio);
        }
    }

    private void ReiniciarEscena()
    {        
        string Test = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(Test);
    }
}
