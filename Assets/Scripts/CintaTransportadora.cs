using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CintaTransportadora : MonoBehaviour
{
    [Header("Velocidad desplazamiento")]
    [Tooltip("Fuerza de la velocidad")] public float velocidad = 10;
    [Header("Dirección a la que va")]
    [Tooltip("Si va en horizontal o vertical")] public Vector2 direction = Vector2.right;
    public MovimientoJugador jugador;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
       if(jugador!= null)
        {
            jugador.controller.Move(direction * velocidad * Time.deltaTime);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugador = other.GetComponent<MovimientoJugador>();
        }
    }
    public void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            jugador = null;
        }
    }
}
