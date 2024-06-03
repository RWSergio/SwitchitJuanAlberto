using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Librerías añadidas
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text puntosTXT;
    public Text nombreTXT;
    public GameObject panelGO;
    public GameObject rankingGO;
    int fechaDB;

   

    

    public void GuardarInformacionDB()
    {
        rankingGO.GetComponent<RankingManager>().InsertarPuntos(nombreTXT.text, fechaDB);
    }
}
