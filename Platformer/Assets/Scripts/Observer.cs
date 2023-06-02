using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    private float speed =  3.5f;
    private Vector3 dir;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        dir = transform.right;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private States State
    {
        get => (States)animator.GetInteger("state");
        set => animator.SetInteger("state", (int)value);
    }

    private void Move()
    {
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.1f + transform.right * dir.x * 0.45f, 0.01f);
        if (colliders.Length > 0)
        {
            dir *= -1f;
            spriteRenderer.flipX = dir.x < 0;
        }
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, Time.deltaTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        State = States.Run;
    }

    // Update is called once per frame
    void Update()
    {
        Move();   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            dir *= -1f;
            spriteRenderer.flipX = dir.x < 0;
        }
        
    }
}
