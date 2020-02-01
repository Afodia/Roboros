using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    Rigidbody2D rg2d;
    Animator animator;
    SpriteRenderer spriteRenderer;
    bool isGrounded = false;

    [SerializeField] Transform groundCheck = null;

    [SerializeField] float runSpeed = 4;
    [SerializeField] float jumpForce = 5;

    private void Awake()
    {
        rg2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

/*    private void Update()
    {
        animator.SetBool("isGrounded", isGrounded);
        if (rg2d.velocity.x > 0.01 || rg2d.velocity.x < -0.01)
            animator.SetBool("isRunning", true);
        else
            animator.SetBool("isRunning", false);
        animator.SetBool("isJumping", rg2d.velocity.y > 0);
        animator.SetBool("isFalling", rg2d.velocity.y < 0);
    }
    */
    void FixedUpdate()
    {
        isGrounded = (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")));

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            rg2d.velocity = new Vector2(runSpeed, rg2d.velocity.y);
            spriteRenderer.flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rg2d.velocity = new Vector2(-runSpeed, rg2d.velocity.y);
            spriteRenderer.flipX = true;
        }
        else
        {
            rg2d.velocity = new Vector2(0, rg2d.velocity.y);
        }

        if (Input.GetAxisRaw("Jump") > 0)
        {
            rg2d.velocity = new Vector2(rg2d.velocity.x, jumpForce);
        }
    }
}
