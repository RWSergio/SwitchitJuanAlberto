using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingScript : MonoBehaviour
{

    //Variables para acceder a los objetos Text
    public Text Posicion, Nombre, Puntos;

    //M�todo para poner los puntos en la UI
    public void PonerPuntos(string pos, string nombre, string fecha)
    {
        Posicion.text = pos;
        Nombre.text = nombre;
        Puntos.text = fecha;
    }
}
