using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    private Rigidbody2D player;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private bool jump = false;

    public enum state
    {
        ONE_ARM = 3,
        TWO_ARMS = 5,
        HUMAN = 6
    };

    [SerializeField] public state currState = state.ONE_ARM;

    [SerializeField] Transform groundCheck = null;

    [SerializeField] float jumpForce = 5;

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Move()
    {
        int rand = Random.Range(1, 3);
        if (Input.GetAxisRaw("Horizontal") > 0) {
            player.velocity = new Vector2((int)currState, player.velocity.y);
            Speed.instance.speed = 1f;
            FindObjectOfType<AudioManager>().Play("outsideWalk"+ rand);
            spriteRenderer.flipX = false;
        } else if (Input.GetAxisRaw("Horizontal") < 0) {
            player.velocity = new Vector2(-(int)currState, player.velocity.y);
            Speed.instance.speed = -1f;
            FindObjectOfType<AudioManager>().Play("outsideWalk"+ rand);
            spriteRenderer.flipX = true;
        } else {
            Speed.instance.speed = 0f;
            player.velocity = new Vector2(0, player.velocity.y);
        }
    }

    void SetAnim()
    {
        anim.SetBool("ONE", currState == state.ONE_ARM ? true : false);
        anim.SetBool("TWO", currState == state.TWO_ARMS ? true : false);
        anim.SetBool("HUMAN", currState == state.HUMAN ? true : false);
        
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
