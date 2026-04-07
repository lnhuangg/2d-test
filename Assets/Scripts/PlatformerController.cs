using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public int coinsCollected = 0;
    bool isGrounded = false;

    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();
        Debug.Log(v);

        rb.linearVelocity = new Vector2(v.x * speed, rb.linearVelocity.y);
    }

    void OnJump()
    {
        if (isGrounded)
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Floor"))
            isGrounded = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Floor"))
            isGrounded = false;
    }
}
