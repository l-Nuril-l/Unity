using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum States
{ 
    Idle,
    Run,
    Jump,
    Fall,
    DoubleJump
}



public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float lives = 5;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private Text livesText;
    [SerializeField] private Joystick joystick;

    internal void EatFruit()
    {
        lives++;
        livesText.text = $"Lives: {lives}";
    }

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;
    private bool isGrounded = false;
    private bool doubleJump = false;
    private DateTime lastJump;

    private void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
        foreach (var item in FindObjectsOfType<Text>())
        {
            if (item.tag == "LivesText")
            {
                livesText = item;
                break;
            }
        }
        
        livesText.text = $"Lives: {lives}";
    }

    private void Start()
    {
        joystick = FindObjectOfType<VariableJoystick>();
    }

    private States State
    {
        get => (States)animator.GetInteger("state");
        set => animator.SetInteger("state",(int)value);
    }

    private void CheckGround()
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3f);


        

        isGrounded = colliders.Length > 1;
        if (isGrounded && !doubleJump) doubleJump = true;

        
    }

    private void Run()
    {
        var AxisJoys = joystick.Horizontal;
        Vector3 dir;
        if (AxisJoys != 0)
            dir = transform.right * joystick.Horizontal;
        else
            dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
        State = States.Run;

    }

    private void Jump()
    {
        rb.Sleep();
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    private void Update()
    {
        if (isGrounded)
        {
            State = States.Idle;
        }

        if (Input.GetButton("Horizontal") || joystick.Horizontal != 0)
        {
            Run();
        }
        if ((DateTime.Now - lastJump).TotalSeconds > 0.5 && (Input.GetButtonDown("Jump") || joystick.Vertical >= .60f))
        {
            if (isGrounded)
            {
                Jump();
                lastJump = DateTime.Now;
            }
            else if (doubleJump)
            {
                Jump();
                doubleJump = false;
            }
        }

        if (rb.velocity.y < -0.001f)
        {
            State = States.Fall;
        }
        else if (rb.velocity.y > .1f)
        {
            if(doubleJump)
                State = States.Jump;
            else
                State = States.DoubleJump;
        }
    }

    private void FixedUpdate()
    {
        CheckGround();
        if( rb.position.y < -10f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void GetDamage()
    {
        lives--;
        livesText.text = $"Lives: {lives}";
        if(lives == 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
