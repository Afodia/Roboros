using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    private Rigidbody2D player;
    private Animator anim;
    public Animation lol;
    private SpriteRenderer spriteRenderer;
    private bool jump = false;
    private int runSpeed;

    public enum state
    {
        ONE_ARM = 2,
        TWO_ARMS = 4,
        HUMAN = 6
    };

    [SerializeField] public state currState;

    [SerializeField] Transform groundCheck = null;

    [SerializeField] float jumpForce = 5;

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        runSpeed = (int)currState;
        lol = GetComponent<Animation>();
    }

    void Move()
    {
        if (Input.GetAxisRaw("Horizontal") > 0) {
            player.velocity = new Vector2(runSpeed, player.velocity.y);
            Speed.instance.speed = 1f;
            spriteRenderer.flipX = false;
        } else if (Input.GetAxisRaw("Horizontal") < 0) {
            player.velocity = new Vector2(-(int)runSpeed, player.velocity.y);
            Speed.instance.speed = -1f;
            spriteRenderer.flipX = true;
        } else {
            Speed.instance.speed = 0f;
            player.velocity = new Vector2(0, player.velocity.y);
        }
    }

    void SetAnim()
    {
        if (currState == state.ONE_ARM)
        {
            anim.SetBool("ONE", true);
            anim.SetBool("TWO", false);
            anim.SetBool("HUMAN", false);
        }
        else if (currState == state.TWO_ARMS)
        {
            anim.SetBool("ONE", false);
            anim.SetBool("TWO", true);
            anim.SetBool("HUMAN", false);
        }
        else if (currState == state.HUMAN)
        {
            anim.SetBool("ONE", false);
            anim.SetBool("TWO", false);
            anim.SetBool("HUMAN", true);
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
            anim.SetBool("IsMoving", true);
        else if (Input.GetAxisRaw("Horizontal") < 0)
            anim.SetBool("IsMoving", true);
        else
            anim.SetBool("IsMoving", false);
    }

    void CheckJump()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")) &&
            currState == state.HUMAN) {
            jump = false;
            //            anim.SetBool("isJumping", false);
        }

        if (Input.GetAxisRaw("Jump") > 0 && !jump && currState == state.HUMAN) {
            player.velocity = new Vector2(player.velocity.x, jumpForce);
            jump = true;
        }
    }

    void FixedUpdate()
    {
        CheckJump();
        SetAnim();
        if (currState != state.ONE_ARM)
            Move();
    }
}
