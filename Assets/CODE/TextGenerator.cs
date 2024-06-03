using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextGenerator : MonoBehaviour
{
    public GameObject mecanicas;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            mecanicas.SetActive(true);
        }
    }
}
