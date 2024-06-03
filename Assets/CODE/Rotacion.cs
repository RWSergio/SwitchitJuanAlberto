using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Este script es para la rotaci�n del nivel
/// </summary>
public class Rotacion : MonoBehaviour
{
    private float anguloActual = 0.0f;
    [Header("Duraci�n")]
    public float duracionRotacion = 0.5f; // Duraci�n en segundos de la rotaci�n
    private Quaternion rotacionInicial;
    private Quaternion rotacionDeseada;
    public static bool estaRotando = false;
    [Header("Objeto referencia rotaci�n")]
    public GameObject Escenario;
    //sonidos//

    private void Start()
    {
        rotacionInicial = transform.rotation;
       
    }

   
    public void Girar90GradosIzquierda()
    {
        if (!estaRotando && MovimientoJugador.groundedPlayer)
        {          
            Escenario.transform.parent = transform;

            rotacionDeseada = Quaternion.Euler(0.0f, 0.0f, anguloActual + 90.0f);
            anguloActual += 90.0f;
            if (anguloActual >= 360.0f)
                anguloActual -= 360.0f;
            estaRotando = true;
        }
    }

    public void Girar90GradosDerecha()
    {
        if (!estaRotando && MovimientoJugador.groundedPlayer)
        {            
            Escenario.transform.parent = transform;
            rotacionDeseada = Quaternion.Euler(0.0f, 0.0f, anguloActual - 90.0f);
            anguloActual -= 90.0f;
            if (anguloActual <= 360.0f)
                anguloActual += 360.0f;
            estaRotando = true;
        }
    }

    private void Update()
    {
        if (estaRotando)
        {
            float velocidadRotacion = 90.0f / duracionRotacion;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacionDeseada, velocidadRotacion * Time.deltaTime);
            if (transform.rotation == rotacionDeseada)
            {
                estaRotando = false;
                Escenario.transform.parent = null;                
            }
        }
    }  
}
