using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Este script sirve para la c�mara del jugador
/// </summary>
public class CamaraJugador : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;  // El objeto que la c�mara seguir�
    public Vector3 offset = new Vector3(0f, 2f, -10f);  // Offset de la posici�n de la c�mara respecto al objetivo
    public float smoothSpeed = 5f;  // Suavidad del movimiento de la c�mara


    private void LateUpdate()
    {
        if (target != null)
        {
            // Calcula la posici�n a la que debe moverse la c�mara
            Vector3 desiredPosition = target.position + offset;

            // Aplica una transici�n suave hacia la posici�n deseada
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

            // Actualiza la posici�n de la c�mara
            transform.position = smoothedPosition;
        }
    }
}
