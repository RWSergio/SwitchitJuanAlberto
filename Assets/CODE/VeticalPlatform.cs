using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeticalPlatform : MonoBehaviour
{
    public GameObject Player;
    public Transform puntoInicio; // Define el punto inicial
    public Transform puntoFin;    // Define el punto final
    public float velocidad = 2.0f; // Velocidad de movimiento

    private Vector3 objetivo;      // Posición objetivo actual

    void Start()
    {
        // Configura la posición inicial como punto de inicio
        transform.position = puntoInicio.position;
        objetivo = puntoFin.position;
    }

    void Update()
    {
        // Mueve el cubo hacia el objetivo
        transform.position = Vector3.MoveTowards(transform.position, objetivo, velocidad * Time.deltaTime);

        // Si el cubo alcanza el punto final, cambia el objetivo al punto inicial
        if (transform.position == puntoFin.position)
        {
            objetivo = puntoInicio.position;
        }
        // Si el cubo alcanza el punto inicial, cambia el objetivo al punto final
        else if (transform.position == puntoInicio.position)
        {
            objetivo = puntoFin.position;
  
        }
    }

 
}
