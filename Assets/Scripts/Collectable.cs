using UnityEngine;

public class Collectable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            PlatformerController p = col.GetComponent<PlatformerController>();
            p.coinsCollected++;
            Debug.Log(p.coinsCollected);
            Destroy(this.gameObject);
        }
    }
}
