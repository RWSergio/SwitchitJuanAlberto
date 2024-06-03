using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Este script es para manejar el sonido de los pasos de caminar del jugador.
/// </summary>
public class Footsteps : MonoBehaviour
{
    public AudioSource footSteps;
    // Start is called before the first frame update
    private void Start()
    {
        footSteps = GameObject.Find("footsteps").GetComponent<AudioSource>();
        if (GameObject.Find("footsteps").GetComponent<AudioSource>() == null)
        {
            print("Sergio, has cambiado el nombre al objeto footsteps??");
        }
    }
    public void Steps()
    {
        footSteps.Play();
    }
}
