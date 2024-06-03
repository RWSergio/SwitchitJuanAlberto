using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //sonidos//
    public AudioSource uiClick;
    public void PlaySound()
    {
        uiClick.Play();
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Creditos()
    {
        SceneManager.LoadScene(10);
    }

}
