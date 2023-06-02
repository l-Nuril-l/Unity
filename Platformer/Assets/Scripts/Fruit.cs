using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var hero = collision.gameObject.GetComponent<Hero>();
            hero.EatFruit();
            Destroy(this.gameObject);
        }
    }
}
