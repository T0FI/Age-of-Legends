using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player4Controller : MonoBehaviour
{

    //Movement variables
    public float maxSpeed = 12;

    //Jumping Variables
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    public bool isAttacked = false;


    Rigidbody2D myRB;
    Animator myAnim;
    bool facingRight;

    //Health
    public int maxHealth = 60;
    public int currentHealth;
    public playerHealth healthBar;

    //Attack bool
    bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();



        facingRight = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (currentHealth == 0)
        {
            maxSpeed = 0;
            myAnim.Play("Hero4 Death");
            myAnim.Play("FadeOut");
            StartCoroutine(Dead());

        }

      

        if ((Input.GetButtonDown("Fire1") && !isAttacking))
        {
            isAttacking = true;

            maxSpeed = 5;


            myAnim.Play("Hero4 Attack");

            StartCoroutine(DoAttack());
            StartCoroutine(Idle());
            StartCoroutine(Speed());
            StartCoroutine(AttackHitBox());

            if (Input.GetButtonDown("Fire1") && (grounded == false))
            {
                isAttacking = true;
                myAnim.Play("Hero4 Attack");
                StartCoroutine(DoAttackInAir());
                StartCoroutine(AttackHitBox());


            }


        }

        if (grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myAnim.SetBool("isGrounded", grounded);
            myRB.AddForce(new Vector2(0, jumpHeight));

        }



    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "EyeEnemy")
        {
            if (isAttacked == false)
            {
                StartCoroutine(Attacked());

                print("yes");
                currentHealth -= 10;
                myAnim.Play("Hero4 TakeHit");
                healthBar.SetHealth(currentHealth);


                StartCoroutine(Idle());

            }
        }
    }

    IEnumerator Attacked()
    {
        isAttacked = true;
        yield return new WaitForSeconds(2f);
        isAttacked = false;
    }


    IEnumerator Speed()
    {
        yield return new WaitForSeconds(.2f);
        maxSpeed = 10;
    }

    IEnumerator AttackHitBox()
    {;
        yield return new WaitForSeconds(.1f);
    }

    IEnumerator DoAttack()
    {
        yield return new WaitForSeconds(1.2f);
        maxSpeed = 10;
        isAttacking = false;
    }

    IEnumerator DoAttackInAir()
    {
        yield return new WaitForSeconds(1.2f);
        myAnim.Play("Hero4 Fall");
        maxSpeed = 10;
        isAttacking = false;
    }

    IEnumerator Idle()
    {
        yield return new WaitForSeconds(.2f);
        myAnim.Play("Hero4 Idle");
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(3);
    }


    void FixedUpdate()
    {

        // Check if we are grounded - if not, then we are falling
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnim.SetBool("isGrounded", grounded);

        myAnim.SetFloat("verticalSpeed", myRB.velocity.y);



        float move = Input.GetAxis("Horizontal");

        myAnim.SetFloat("Speed", Mathf.Abs(move));

        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);


        if (move > 0 && facingRight)
        {
            flip();
        }
        else if (move < 0 && !facingRight)
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
