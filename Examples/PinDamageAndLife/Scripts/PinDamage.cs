using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float damageAmount;
    [SerializeField] float knockbackForce;
    [SerializeField] Color damageColor;
    Color originalColor;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        originalColor = GetComponent<SpriteRenderer>().color;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Pins")
        {
            TakeDamage();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pins")
        {
            rb.AddForce(new Vector2(1.75f, 1.75f) * knockbackForce);
            Debug.Log("Volviendo a colisionar con los pinchos");
        }
    }

    void TakeDamage()
    {
        GetComponent<SpriteRenderer>().color = damageColor;
        //rb.velocity = new Vector2(0f, 0f);
        if (rb.velocity.y < 0)
        {
            rb.AddForce(new Vector2(1.75f, 1.75f) * knockbackForce);
            Debug.Log("Cayendo e impulsando hacia delante");
        }
        else
        {
            transform.position = new Vector2(transform.position.x - 0.8f, transform.position.y);
            Debug.Log("Retrocediendo Transform X");
        }
        Invoke("ResetColor", 0.25f);
    }

    void ResetColor()
    {
        GetComponent<SpriteRenderer>().color = originalColor;
    }
}
