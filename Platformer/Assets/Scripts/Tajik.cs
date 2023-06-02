using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tajik : Entity
{
    private void Start()
    {
        lives = 2;
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
}
