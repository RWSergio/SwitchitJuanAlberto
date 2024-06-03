using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Este script sirve para la cámara del jugador
/// </summary>
public class CamaraJugador : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;  // El objeto que la cámara seguirá
    public Vector3 offset = new Vector3(0f, 2f, -10f);  // Offset de la posición de la cámara respecto al objetivo
    public float smoothSpeed = 5f;  // Suavidad del movimiento de la cámara


    private void LateUpdate()
    {
        if (target != null)
        {
            // Calcula la posición a la que debe moverse la cámara
            Vector3 desiredPosition = target.position + offset;

            // Aplica una transición suave hacia la posición deseada
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

            // Actualiza la posición de la cámara
            transform.position = smoothedPosition;
        }
    }
}
