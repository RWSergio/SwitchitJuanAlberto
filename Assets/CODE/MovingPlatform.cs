using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Este script es para las plataformas móviles
/// </summary>
public class MovingPlatform : MonoBehaviour
{
    public GameObject Player;
    [Header("Posiciones Plataforma")]
    public Transform platform;
    public Transform startPoint;
    public Transform endPoint;

    int direction = 1;
    public float speed = 0.5f;
    // Start is called before the first frame update
    private void Update()
    {
        Vector2 target = currentMovementTarget();

        platform.position = Vector2.Lerp(platform.position, target, speed * Time.deltaTime);

        float distance = (target - (Vector2)platform.position).magnitude;

        if(distance<= 0.1f)
            direction *= -1;
    }

    Vector2 currentMovementTarget()
    {
        if(direction == 1)
            return startPoint.position;
        else
            return endPoint.position;
    }

    // Update is called once per frame
    private void OnDrawGizmos()
    {
        if(platform!=null && startPoint!=null && endPoint != null)
        {
            Gizmos.DrawLine(platform.transform.position, startPoint.position);
            Gizmos.DrawLine(platform.transform.position, endPoint.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
            Player.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
            Player.transform.parent = null;
    }
}
