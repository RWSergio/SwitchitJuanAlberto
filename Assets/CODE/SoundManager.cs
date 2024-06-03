using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioSource audioSource;

    void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    public void EjecutarSonido(AudioClip sonido)
    {
        audioSource.PlayOneShot(sonido);
    }
    
}
