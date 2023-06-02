using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var hero = collision.gameObject.GetComponent<Hero>();
            hero.GetDamage();
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.tag == "Player")
    //    {
    //        var hero = collision.gameObject.GetComponent<Hero>();
    //        hero.GetDamage();
    //    }
    //}
}
