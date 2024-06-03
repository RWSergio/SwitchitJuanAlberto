using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForce : MonoBehaviour
{
    [Header("Dirección de la fuerza")]
    public Vector3 direccion;


    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<MovimientoJugador>().publicdireccion = direccion;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<MovimientoJugador>().publicdireccion = Vector3.zero;
            other.GetComponent<MovimientoJugador>().playerVelocity.y = 0;
        }
    }
}
