using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Este script es para el fondo que se mueve en loop del menú principal.
/// </summary>
public class BackgroundLoop : MonoBehaviour
{
    public float speed;
 
    public Transform fondo;
    //public Transform fondo2;
    // Update is called once per frame
    void Update()
    {

        fondo.transform.position += new Vector3(transform.position.x, 0.00000000001f, 0f) * Time.deltaTime;
        //fondo2.transform.position += new Vector3(transform.position.x, 0.00000000001f, 0f) * Time.deltaTime;

        if(fondo.transform.position.x >= 600f)
            fondo.transform.position = new Vector3(300f, transform.position.y, 0f);
        //if (fondo2.transform.position.x >= 800f)
        //{
        //    fondo2.transform.position = new Vector3(-50f, transform.position.y, 0f);
        //}
    }   
}
