using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void OpenLevel(int levelId)
    {
        string levelName = "Nivel" + levelId; 
        SceneManager.LoadScene(levelName);
    }

    public void Volver()
    {
        SceneManager.LoadScene(0);
    }
}
