using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player2Controller : MonoBehaviour
{

    //Movement variables
    public float maxSpeed = 10;

    //Jumping Variables
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    [SerializeField]
    GameObject attack1Hitbox;

    public bool isAttacked = false;

    Rigidbody2D myRB;
    Animator myAnim;
    bool facingRight;

    //Health
    public int maxHealth = 80;
    public static int currentHealth;
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

        attack1Hitbox.SetActive(false);

        facingRight = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (currentHealth <= 0)
        {
            maxSpeed = 0;
            myAnim.Play("Hero2 Death");
            myAnim.Play("FadeOut");
            StartCoroutine(Dead());

        }

        if (currentHealth > 80)
        {
            currentHealth = 80;
        }


        if ((Input.GetButtonDown("Fire1") && !isAttacking))
        {
            isAttacking = true;
            FindObjectOfType<audioManager>().Play("Player Attack Sword");
            maxSpeed = 5;

            myAnim.Play("Hero2 Attack");

            StartCoroutine(DoAttack());
            StartCoroutine(Idle());
            StartCoroutine(Speed());
            StartCoroutine(AttackHitBox());

            if (Input.GetButtonDown("Fire1") && (grounded == false))
            {
                isAttacking = true;
                myAnim.Play("Hero2 Attack");
                StartCoroutine(DoAttackInAir());
                StartCoroutine(AttackHitBox());


            }


        }

        if (grounded && Input.GetAxis("Jump") > 0)
        {
            FindObjectOfType<audioManager>().Play("Player Jump");
            grounded = false;
            myAnim.SetBool("isGrounded", grounded);
            myRB.AddForce(new Vector2(0, jumpHeight));

        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "deathFall")
        {
            if (isAttacked == false)
            {
                StartCoroutine(Attacked());

                currentHealth -= 1000;
                myAnim.Play("Hero2 TakeHit");
                healthBar.SetHealth(currentHealth);


                StartCoroutine(Idle());

            }
        }

        if (other.gameObject.tag == "EyeEnemy")
        {
            if (isAttacked == false)
            {
                StartCoroutine(Attacked());

                currentHealth -= 10;
                myAnim.Play("Hero2 TakeHit");
                healthBar.SetHealth(currentHealth);

                myAnim.Play("Herohurt");
                StartCoroutine(kbackScriptP2.instance.Knockback(0.02f, 1400, kbackScriptP2.instance.transform.position));
                StartCoroutine(Idle());

            }
        }

        if (other.gameObject.tag == "TrashEnemy")
        {
            if (isAttacked == false)
            {
                StartCoroutine(Attacked());

                currentHealth -= 10;
                myAnim.Play("Hero2 TakeHit");
                healthBar.SetHealth(currentHealth);

                myAnim.Play("Herohurt");
                StartCoroutine(kbackScriptP2.instance.Knockback(0.02f, 1400, kbackScriptP2.instance.transform.position));
                StartCoroutine(Idle());

            }
        }



    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Heart")
        {

            currentHealth += 20;
            healthBar.SetHealth(currentHealth);

        }


        if (other.gameObject.tag == "skeletonHitBox")
        {
            if (isAttacked == false)
            {
                StartCoroutine(Attacked());

                currentHealth -= 20;
                myAnim.Play("Hero2 TakeHit");
                healthBar.SetHealth(currentHealth);

                myAnim.Play("Herohurt");
                StartCoroutine(kbackScriptP2.instance.Knockback(0.02f, 1400, kbackScriptP2.instance.transform.position));

                StartCoroutine(Idle());

            }
        }

        if (other.gameObject.tag == "bossMelee")
        {
            if (isAttacked == false)
            {
                StartCoroutine(Attacked());

                currentHealth -= 5;
                myAnim.Play("Hero2 TakeHit");
                healthBar.SetHealth(currentHealth);

                myAnim.Play("Herohurt");
                StartCoroutine(kbackScriptP2.instance.Knockback(0.02f, 1400, kbackScriptP2.instance.transform.position));
                StartCoroutine(Idle());

            }
        }

        if (other.gameObject.tag == "bossBullet")
        {
            if (isAttacked == false)
            {
                StartCoroutine(Attacked());

                currentHealth -= 10;
                myAnim.Play("Hero2 TakeHit");
                healthBar.SetHealth(currentHealth);

                myAnim.Play("Herohurt");
                StartCoroutine(kbackScriptP2.instance.Knockback(0.02f, 1400, kbackScriptP2.instance.transform.position));
                StartCoroutine(Idle());

            }
        }

        if (other.gameObject.tag == "bossMinion")
        {
            if (isAttacked == false)
            {
                StartCoroutine(Attacked());

                currentHealth -= 2;
                myAnim.Play("Hero2 TakeHit");
                healthBar.SetHealth(currentHealth);

                myAnim.Play("Herohurt");
                StartCoroutine(kbackScriptP2.instance.Knockback(0.02f, 1400, kbackScriptP2.instance.transform.position));
                StartCoroutine(Idle());

            }
        }

    }



    IEnumerator Attacked()
    {
        FindObjectOfType<audioManager>().Play("Player TakeHit");
        isAttacked = true;
        yield return new WaitForSeconds(1f);
        isAttacked = false;
    }

    IEnumerator Speed()
    {
        yield return new WaitForSeconds(.2f);
        maxSpeed = 10;
    }

    IEnumerator AttackHitBox()
    {
        attack1Hitbox.SetActive(true);
        yield return new WaitForSeconds(.1f);
        attack1Hitbox.SetActive(false);
    }

    IEnumerator DoAttack()
    {
        yield return new WaitForSeconds(1f);
        maxSpeed = 10;
        isAttacking = false;
    }

    IEnumerator DoAttackInAir()
    {
        yield return new WaitForSeconds(1f);
        myAnim.Play("Hero2 Fall");
        maxSpeed = 10;
        isAttacking = false;
    }

    IEnumerator Idle()
    {
        yield return new WaitForSeconds(.2f);
        myAnim.Play("Hero2 Idle");
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(1.5f);
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