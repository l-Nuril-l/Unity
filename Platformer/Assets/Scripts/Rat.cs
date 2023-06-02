using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : Entity
{
    private void Start()
    {
        lives = 5;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var hero = collision.gameObject.GetComponent<Hero>();
            hero.GetDamage();
            GetDamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Splash"))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce(transform.right * -20, ForceMode2D.Impulse);
        }
    }
}
