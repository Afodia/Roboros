using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    private Rigidbody2D player;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private bool jump = false;
    private int runSpeed;
    private static int frameMove = 25;
    private static int frameCount = 0;

    public enum state
    {
        ONE_ARM = 2,
        TWO_ARMS = 4,
        HUMAN = 6
    };

    private state currState;

    [SerializeField] Transform groundCheck = null;
    [SerializeField] Transform groundCheckLeft = null;
    [SerializeField] Transform groundCheckRight = null;

    [SerializeField] float jumpForce = 5;

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currState = state.ONE_ARM;
        runSpeed = (int)currState;
    }

    void Move()
    {
        if (Input.GetAxisRaw("Horizontal") > 0) {
            if (currState != state.ONE_ARM || (frameMove <= frameCount && currState == state.ONE_ARM)) {
                player.velocity = new Vector2(runSpeed, player.velocity.y);
            }
            spriteRenderer.flipX = false;
        } else if (Input.GetAxisRaw("Horizontal") < 0) {
            if ((frameMove <= frameCount && currState == state.ONE_ARM) || currState != state.ONE_ARM)
            player.velocity = new Vector2(-(int)runSpeed, player.velocity.y);
            spriteRenderer.flipX = true;
        } else {
            player.velocity = new Vector2(0, player.velocity.y);
        }

    }

    void CheckJump()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")) ||
            Physics2D.Linecast(transform.position, groundCheckLeft.position, 1 << LayerMask.NameToLayer("Ground")) ||
            Physics2D.Linecast(transform.position, groundCheckRight.position, 1 << LayerMask.NameToLayer("Ground")) &&
            currState == state.HUMAN) {
            jump = false;
            //            anim.SetBool("isJumping", false);
        }

        if (Input.GetAxisRaw("Jump") > 0 && !jump) {
            player.velocity = new Vector2(player.velocity.x, jumpForce);
            jump = true;
        }
    }

    void FixedUpdate()
    {
        frameCount += 1;

        CheckJump();
        Move();

        if (frameCount == 48)
            frameCount = 0;
    }
}
