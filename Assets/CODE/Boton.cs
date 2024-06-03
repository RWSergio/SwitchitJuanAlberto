using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Este script es para cuando el jugador toca el botón, y que interactue con otro objeto.
/// </summary>


public class Boton : MonoBehaviour
    {
      [Header("Desaparece")]
        public GameObject objetoQueDesaparecera;
    [Header("Aparece")]
    public GameObject objetoQueAparece;


    private void OnTriggerEnter(Collider other)
        {
            // Verifica si el objeto que colisionó es el "Player"
            if (other.CompareTag("Player"))
            {
                // Desactiva el objeto que debe desaparecer
                objetoQueDesaparecera.SetActive(false);
            objetoQueAparece.SetActive(true);
            }
        }
    }
