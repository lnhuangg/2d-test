using System;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlatformerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public int coinsCollected = 0;
    bool isGrounded = false;
    bool canDoubleJump = true;


    private Animator playerAnim;

    private SpriteRenderer playerSpriteRenderer;
    bool isFacingRight = true;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        playerAnim.SetBool("isGrounded", isGrounded);

    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();
        Debug.Log(v);

        rb.linearVelocity = new Vector2(v.x * speed, rb.linearVelocity.y);
        playerAnim.SetBool("isRunning", rb.linearVelocity.x != 0);
        if((v.x < 0) && isFacingRight)
        {    
            playerSpriteRenderer.flipX = true;
            isFacingRight = false;
        }
        if ((v.x > 0) && !isFacingRight)
        {
            playerSpriteRenderer.flipX = false;
            isFacingRight = true;
        }
    }

    void OnTeleport(InputValue value)
    {
        Vector2 targetPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        rb.position = targetPos;
    }

    void OnJump()
    {
        if (isGrounded)
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        else if (canDoubleJump)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            canDoubleJump = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Floor"))
        {
            isGrounded = true;
            canDoubleJump = true;
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Floor"))
            isGrounded = false;
    }
}
