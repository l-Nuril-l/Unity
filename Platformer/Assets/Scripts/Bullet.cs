using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    public float startTime = 0;
    public float endTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        var rb = GetComponent<Rigidbody2D>();
        var sr = FindObjectOfType<Hero>().GetComponentInChildren<SpriteRenderer>();
        rb.velocity = transform.right * speed * (sr.flipX ? -1 : 1);
        GetComponentInChildren<SpriteRenderer>().flipX = !sr.flipX;
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if(collision.CompareTag("Enemy"))
         {
            collision.GetComponent<Entity>().GetDamage();
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        startTime += 1f * Time.deltaTime;
        if(startTime > endTime)
            Destroy(gameObject);
    }
}
