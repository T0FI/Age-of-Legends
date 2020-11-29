using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMinionTest : MonoBehaviour
{
    //https://www.youtube.com/watch?v=fviU0V6nivs&ab_channel=ChronoABI

    public float speed;
    public int eHealth;
    private bool movingRight = false;
    private float moveDirection = -1;

    public float circleRadius;
    public LayerMask groundLayer;
    public Transform groundChecker;
    public Transform wallChecker;
    private bool checkingWall;
    private bool checkingGround;

    public float jumpHeight;

    Transform Player;
    Transform Player2;
    Transform Player3;
    Transform Player4;
    Transform Player5;

    public Vector2 lineOfSight;
    public LayerMask playerLayer;
    public bool canSeePlayer;

    GameObject Hero1;
    GameObject Hero2;
    GameObject Hero3;
    GameObject Hero4;
    GameObject Hero5;

    public Transform groundCheck2;
    public Vector2 boxSize;
    public bool isGrounded;

    Rigidbody2D enemyRB;
    Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {
        Player  = GameObject.Find("Hero5").GetComponent<Transform>();

        Hero1 = GameObject.Find("Hero5");
       

        this.enemyRB = gameObject.GetComponent<Rigidbody2D>();
        this.myAnim = gameObject.GetComponent<Animator>();
        Debug.Log(enemyRB, myAnim);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        if(myAnim == null)
        {
            Debug.Log("MyAnimator is not set");
            return;
        }
        */
        checkingGround = Physics2D.OverlapCircle(groundChecker.position, circleRadius, groundLayer);
        checkingWall = Physics2D.OverlapCircle(wallChecker.position, circleRadius, groundLayer);
        isGrounded = Physics2D.OverlapBox(groundCheck2.position, boxSize, 0, groundLayer);
        canSeePlayer = Physics2D.OverlapBox(transform.position, lineOfSight, 0, playerLayer);


        AnimationController();

        if (!canSeePlayer && isGrounded)
        {
            Petrolling();
        }

        if (eHealth <= 0)
        {
            speed = 0;
            myAnim.Play("Minion Death");
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        }


    }

    void Petrolling()
    {
        if (!checkingGround || checkingWall)
        {
            if (movingRight)
            {
                Flip();
            }
            else if (!movingRight)
            {
                Flip();
            }
        }
        enemyRB.velocity = new Vector2(speed * moveDirection, enemyRB.velocity.y);
    }

    void JumpAttack()
    {
        float distanceFromPlayer = Player.position.x - transform.position.x;


        if (isGrounded && (Hero1.active == true))
        {
            enemyRB.AddForce(new Vector2(distanceFromPlayer, jumpHeight), ForceMode2D.Impulse);
        }


    }

    void FlipTowardsPlayer()
    {
        float distanceFromPlayer = Player.position.x - transform.position.x;


        if (distanceFromPlayer < 0 && movingRight && (Hero1.active == true))
        {
            Flip();
        }
        else if (distanceFromPlayer > 0 && !movingRight && (Hero1.active == true))
        {
            Flip();
        }

    }

    void Flip()
    {
        moveDirection *= -1;
        movingRight = !movingRight;
        transform.Rotate(0, 180, 0);
    }

    void AnimationController()
    {
        myAnim.SetBool("canSeePlayer", canSeePlayer);
        myAnim.SetBool("isGrounded", isGrounded);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundChecker.position, circleRadius);
        Gizmos.DrawWireSphere(wallChecker.position, circleRadius);

        Gizmos.color = Color.green;
        Gizmos.DrawCube(groundCheck2.position, boxSize);

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, lineOfSight);

    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(2f);
        enemyRB.AddForce(new Vector2(0, 20));
        yield return new WaitForSeconds(.1f);
        enemyRB.AddForce(new Vector2(0, 0));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "attackHitBox")
        {
            myAnim.Play("Minion TakeHit");
            eHealth -= heroDamage.heroADamage;
            print(eHealth);
            StartCoroutine(CheckHealth());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        myAnim.Play("Minion Attack");
        yield return new WaitForSeconds(.5f);
        myAnim.Play("Minion Walk");

    }

    IEnumerator Walk()
    {
        this.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(.3f);
        myAnim.Play("Minion Walk");
    }

    IEnumerator CheckHealth()
    {

        speed = 2;



        yield return new WaitForSeconds(.4f);
        speed = 5;
        myAnim.Play("Minion canSeePlayer");
    }


}
