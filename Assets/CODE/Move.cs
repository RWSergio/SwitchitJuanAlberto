using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 12f;

    private Rigidbody rb;
    private Vector3 _input;

    private void Start()
    {
        TryGetComponent(out rb);
    }

    void Update()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        //transform.Translate(_input.normalized * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(Vector2.up * jumpForce, ForceMode.VelocityChange);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(_input.normalized.x * speed, rb.velocity.y);
    }
}
