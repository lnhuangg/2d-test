using Unity.VisualScripting;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rb;
    [SerializeField] private float bounceForce = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
            rb.AddForce(new Vector2(0, bounceForce), ForceMode2D.Impulse);
    }
}
