using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Este script es para que cambie el sprite de un objeto cuando el jugador entra en contacto con un collider
/// </summary>
public class SpriteChange : MonoBehaviour
{
    [Tooltip("Objeto que se va a cambiar")] public GameObject objetoActivar; // Asigna el objeto a activar desde el Inspector
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que ha entrado en contacto tiene la etiqueta deseada
        if (other.CompareTag("Player"))
        {
            // Activa el objeto deseado
            objetoActivar.SetActive(true);
        }
    }
}