using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;
    public float jumpPower;

    Rigidbody2D body;
    SpriteRenderer spriteRenderer;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && animator.GetBool("isJumping") == false)
        {
            body.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
        }

        //Stop Speed SetUp
        if (Input.GetButtonUp("Horizontal"))
        {            
            body.velocity = new Vector2(body.velocity.normalized.x * 0.5f, body.velocity.y);
        }

        if(Input.GetButtonDown("Horizontal"))
        {
            spriteRenderer.flipX= Input.GetAxisRaw("Horizontal") == -1;
        }

        //Walking Animation
        if(Mathf.Abs(body.velocity.x) < 0.3f)
        {
            animator.SetBool("isWalking",false);
        }
        else
        {
            animator.SetBool("isWalking", true);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        body.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (body.velocity.x > maxSpeed)
        {
            body.velocity = new Vector2(maxSpeed, body.velocity.y);
        }
        else if (body.velocity.x < -maxSpeed)
        {
            body.velocity = new Vector2(-maxSpeed, body.velocity.y);
        }

        if(body.velocity.y < 0)
        {
            Debug.DrawRay(body.position, Vector3.down, Color.green);

            RaycastHit2D rayHit = Physics2D.Raycast(body.position, Vector3.down, 1, LayerMask.GetMask("Platform"));

            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.5f)
                {
                    animator.SetBool("isJumping", false);
                }
            }
        }


    }
}
