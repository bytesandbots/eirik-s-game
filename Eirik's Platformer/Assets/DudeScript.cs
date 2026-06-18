using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeScript : MonoBehaviour
{

    public float speed;
    public float jumpspeed;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        Vector2 move = (transform.right * x) * speed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + move);

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            rb.AddForce(Vector2.up * jumpspeed );
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        rb.gravityScale = 5;
    }

    private void OnCollisionExit2D(Collision2D collision) 
    {
        rb.gravityScale = 100;
    }
}



