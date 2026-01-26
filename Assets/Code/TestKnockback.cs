using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestKnockback : MonoBehaviour
{
    public float knockbackForce = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb !=null)
            {
                Vector2 knockbackDirection = (transform.position -collision.transform.position).normalized;
                rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
            }
        }
    }
// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
