using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float speed;
    private SpriteRenderer spriterenderer;
    public float jumpForce; 
    public bool checkground = true; 

    void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    
    void Update()
    {
        Jump();
    }

    void MovePlayer() 
    {
        float horizontalMoviment = Input.GetAxisRaw("Horizontal");
        rigidbody2D.velocity = new Vector2(horizontalMoviment * speed, rigidbody2D.velocity.y);
        
        if (horizontalMoviment > 0)
        {
            spriterenderer.flipX = false;
        }

        if (horizontalMoviment < 0)
        {
            spriterenderer.flipX = true;
        }
    }

    void Jump()
    {

        if (Input.GetButtonDown("Jump") && checkground)
        {
            rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            checkground = false;
        }
    }

    private void OncollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Ground")
        {
            checkground = true;
            Debug.Log("Chão");
        }
    }
}
