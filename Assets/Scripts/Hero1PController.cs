using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero1PController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    public float Speed;
    public float Jump;

    bool facingRight;
    bool grounded;

    [SerializeField]
    Transform groundCheck;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        facingRight = true;

    }

    // Update is called once per frame
    void Update()
    {
        



    }

    private void FixedUpdate()
    {

        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2d.velocity = new Vector2(Speed, rb2d.velocity.y);
            animator.Play("Hero1 Run");
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2d.velocity = new Vector2(-Speed, rb2d.velocity.y);
            animator.Play("Hero1 Run");
        }
        else
        {
            animator.Play("Hero1 Idle");
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        if(Input.GetKey("d") && Input.GetKey("a"))
        {
            
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }


        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, Jump);
            //animator.Play("Hero1 Jump");
            //animator.Play("Hero1 Run");

        }


        float move = Input.GetAxis("Horizontal");

        if (move > 0 && !facingRight)
        {
            flip();
        }
        else if (move < 0 && facingRight)
        {
            flip();
        }
    }

    void flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

}



