using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Este script es para el panel de pausa del menú
/// </summary>
public class PausePanel : MonoBehaviour
{
    public GameObject pausePanel;

    //sonidos//
    public AudioSource clickUI;
    public AudioSource Music;

    // Update is called once per frame
    public void PlaySound()
    {
        clickUI.Play();
    }

    public void Pause()
    {

        pausePanel.SetActive(true);
        Time.timeScale = 0;
        Music.Pause();

    }

    public void Continue()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        Music.Play();
    }

    public void Casa()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Niveles()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
}
