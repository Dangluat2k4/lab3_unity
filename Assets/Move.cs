using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    private bool nen;
    private bool isJumping = false;
    private bool isGrounded = false;
    public bool isRight = true;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        animator = GetComponent<Animator>();

    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        if (Input.GetKey(KeyCode.RightArrow))
        {
            isRight = true;
            animator.SetBool("isRuning", true);
            transform.Translate(Time.deltaTime * 5, 0, 0);
            Vector2 scale = transform.localScale;
            scale.x *= scale.x > 0 ? 1 : -1;
            // neu scale >0 thi scale lon hon 0 else
            transform.localScale = scale;

        }
        else
        {
            animator.SetBool("isRuning", false);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isRight = false;
            animator.SetBool("isRuning", true);
            transform.Translate(-Time.deltaTime * 5, 0, 0);
            Vector2 scale = transform.localScale;
            scale.x *= scale.x > 0 ? -1 : 1;
            // neu scale >0 thi scale lon hon 0 else
            transform.localScale = scale;

        }
        if (!isJumping && Input.GetKeyDown(KeyCode.Space))
        {
            if (nen == true && isGrounded)
            {
                if (isRight == true)
                {
                    rb.AddForce(new Vector2(0, 6f), ForceMode2D.Impulse);
                    Vector2 scale = transform.localScale;
                    scale.x = Mathf.Abs(scale.x); // Set the x scale to its absolute value
                    transform.localScale = scale;
                }
                else
                {
                    rb.AddForce(new Vector2(0, 6f), ForceMode2D.Impulse);
                    Vector2 scale = transform.localScale;
                    scale.y = Mathf.Abs(scale.y); // Set the x scale to its absolute value
                    transform.localScale = scale;
                }
                nen = false;
                isJumping = true;
            }

        }
    }
    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "nen_dat")
        {
            nen = true;
            isJumping = false;
            isGrounded = true;
        }


    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "nen_dat")
        {
            isGrounded = false;
        }
    }

}
