using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;
using IronPython.Hosting;
using System;
using Microsoft.Scripting.Hosting;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    //public Transform transformPlayer;
    float jumpForce = 8.0f;
    private float horizontalMove;
    private Rigidbody2D rb;
    public bool toRight = true;
    private float speed = 6f;
    private Animator animator;
    private float s;
    private float s1;
    private SpriteRenderer sprite;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void Run()
    {
        
        
        //transformPlayer.position = new Vector2(horizontalMove * speed, 0f);
        //animator.Play("Player_Run");
    }

    void flip()
    {
        toRight = !toRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

   

    private void Update()
    {
        horizontalMove = CrossPlatformInputManager.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalMove * speed, 0f);

        if (horizontalMove < 0f && toRight)
        {
            flip();
        }

        if (horizontalMove > 0f && !toRight)
        {
            flip();
        }


        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            UnityEngine.Debug.Log("J!");
        }
       

        if (horizontalMove == 0f)
        {
            animator.Play("Player_Idle");
        }
        else
        {
            animator.Play("Player_Run");
        }
    }

    public void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       // if (collision.gameObject.tag == "Ground") isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Ground") isGrounded = false;
        
    }


    public enum CharState
    {
        Idle,Run,Jump
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}


