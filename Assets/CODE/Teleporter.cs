using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Este script es para el teletransportador, yendo a una posición asignada.
/// </summary>
public class Teleporter : MonoBehaviour
{
    [Header("Teletransportación")]
    [Tooltip("Asigna el jugador")] public GameObject Player;
    [Tooltip("Objeto al que se teletransporta")] public GameObject TeleportTo;
    [Header("Sonido Teletransportación")]
    [Tooltip("Sonido que hace al teletransportarse")] public AudioSource TeleportSonido;
    private void Start()
    {
        TeleportSonido.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TeleportSonido.Play();
            Player.GetComponent<CharacterController>().enabled = false;
            Player.transform.position = TeleportTo.transform.position;
            Player.GetComponent<CharacterController>().enabled = true;
        }
    }
}
