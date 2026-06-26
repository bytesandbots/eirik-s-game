using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeScript : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private int jumpAmount;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckRadius = 0.1f;

    private Rigidbody2D rb;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Jump();
    }

    void FixedUpdate()
    {
        // check directly below player only
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // normal gravity always, no need to change it
        rb.gravityScale = isGrounded ? 3f : 5f;
        // here is where I change the jump amount
        if (isGrounded) jumpAmount = 1;

        Move();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
    }

    void Jump()
    {

        switch (jumpAmount) 
        {

            case 1:
                speed = 5f;
                jumpForce = 10f;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    jumpAmount--;
                }
                break;
            case 2:
                speed = 5f;
                jumpForce = 10f;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    jumpAmount--;
                }
                break;  
        }
            



       
    }
}


