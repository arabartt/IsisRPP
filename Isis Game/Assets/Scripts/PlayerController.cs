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
    public float raysize;
    public LayerMask groundlayer;
    public bool checkJump; 
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
        Groundcheck();
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

        if (Input.GetButtonDown("Jump"))
        {
            if (checkground)
            {
                rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
            else if (checkJump)
            {
                rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                checkJump = false;
            }
        }
    }

   

    void Groundcheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raysize, groundlayer);
        checkground = hit.collider != null;
        if (checkground)
        {
            checkJump = true; 
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position,Vector3.down * raysize, Color.red);
    }
}
