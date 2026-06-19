using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouCheatDeath: MonoBehaviour
{
    public Transform rESPAWNTHINGY;
    Rigidbody2D rb;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -20)
        { 
            transform.position = rESPAWNTHINGY.position;
            rb.gravityScale = 1f;
        }
    }
}
