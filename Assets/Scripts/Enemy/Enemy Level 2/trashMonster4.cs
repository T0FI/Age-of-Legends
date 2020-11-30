using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashMonster4 : MonoBehaviour
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
    public Transform Player;
    public Transform Player2;
    public Transform Player3;
    public Transform Player4;
    public Transform Player5;

    public Vector2 lineOfSight;
    public LayerMask playerLayer;
    private bool canSeePlayer;


    public GameObject Hero1;
    public GameObject Hero2;
    public GameObject Hero3;
    public GameObject Hero4;
    public GameObject Hero5;

    public Transform groundCheck2;
    public Vector2 boxSize;
    private bool isGrounded;

    Rigidbody2D enemyRB;
    Animator myAnim;
    GameObject Trash;
    public bool Aggro = false;

    // Start is called before the first frame update
    void Start()
    {

        enemyRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        Trash = GameObject.Find("Trash Monster4");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        checkingGround = Physics2D.OverlapCircle(groundChecker.position, circleRadius, groundLayer);
        checkingWall = Physics2D.OverlapCircle(wallChecker.position, circleRadius, groundLayer);
        isGrounded = Physics2D.OverlapBox(groundCheck2.position, boxSize, 0, groundLayer);
        canSeePlayer = Physics2D.OverlapBox(transform.position, lineOfSight, 0, playerLayer);

        if (Aggro == true)
        {
            AnimationController();

            if (!canSeePlayer && isGrounded)
            {
                Petrolling();
            }
        }

        if (eHealth <= 0)
        {
            speed = 0;
            myAnim.Play("Trash Death");
            Trash.GetComponent<BoxCollider2D>().enabled = false;
            Trash.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

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
        float distanceFromPlayer2 = Player2.position.x - transform.position.x;
        float distanceFromPlayer3 = Player3.position.x - transform.position.x;
        float distanceFromPlayer4 = Player4.position.x - transform.position.x;
        float distanceFromPlayer5 = Player5.position.x - transform.position.x;

        if (isGrounded && (Hero1.active == true))
        {
            enemyRB.AddForce(new Vector2(distanceFromPlayer, jumpHeight), ForceMode2D.Impulse);
        }

        else if (isGrounded && (Hero2.active == true))
        {
            enemyRB.AddForce(new Vector2(distanceFromPlayer2, jumpHeight), ForceMode2D.Impulse);
        }
        else if (isGrounded && (Hero3.active == true))
        {
            enemyRB.AddForce(new Vector2(distanceFromPlayer3, jumpHeight), ForceMode2D.Impulse);
        }
        else if (isGrounded && (Hero4.active == true))
        {
            enemyRB.AddForce(new Vector2(distanceFromPlayer4, jumpHeight), ForceMode2D.Impulse);
        }
        else if (isGrounded && (Hero5.active == true))
        {
            enemyRB.AddForce(new Vector2(distanceFromPlayer5, jumpHeight), ForceMode2D.Impulse);
        }

    }

    void FlipTowardsPlayer()
    {
        float distanceFromPlayer = Player.position.x - transform.position.x;
        float distanceFromPlayer2 = Player2.position.x - transform.position.x;
        float distanceFromPlayer3 = Player3.position.x - transform.position.x;
        float distanceFromPlayer4 = Player4.position.x - transform.position.x;
        float distanceFromPlayer5 = Player5.position.x - transform.position.x;

        if (distanceFromPlayer < 0 && movingRight && (Hero1.active == true))
        {
            Flip();
        }
        else if (distanceFromPlayer > 0 && !movingRight && (Hero1.active == true))
        {
            Flip();
        }

        if (distanceFromPlayer2 < 0 && movingRight && (Hero2.active == true))
        {
            Flip();
        }
        else if (distanceFromPlayer2 > 0 && !movingRight && (Hero2.active == true))
        {
            Flip();
        }

        if (distanceFromPlayer3 < 0 && movingRight && (Hero3.active == true))
        {
            Flip();
        }
        else if (distanceFromPlayer3 > 0 && !movingRight && (Hero3.active == true))
        {
            Flip();
        }

        if (distanceFromPlayer4 < 0 && movingRight && (Hero4.active == true))
        {
            Flip();
        }
        else if (distanceFromPlayer4 > 0 && !movingRight && (Hero4.active == true))
        {
            Flip();
        }

        if (distanceFromPlayer5 < 0 && movingRight && (Hero5.active == true))
        {
            Flip();
        }
        else if (distanceFromPlayer5 > 0 && !movingRight && (Hero5.active == true))
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
        if (collision.gameObject.tag == "Player")
        {
            Aggro = true;
            myAnim.Play("Trash Aggro");
            StartCoroutine(Walk());
        }

        if (collision.gameObject.tag == "attackHitBox")
        {
            myAnim.Play("Trash TakeHit");
            eHealth -= heroDamage.heroADamage;
            print(eHealth);
            StartCoroutine(Attacked());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        myAnim.Play("Trash Attack");
        yield return new WaitForSeconds(.5f);
        myAnim.Play("Trash Walk");

    }

    IEnumerator Walk()
    {
        Trash.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(.3f);
        myAnim.Play("Trash Walk");
    }

    IEnumerator Attacked()
    {
        FindObjectOfType<audioManager>().Play("Enemy TakeHit");
        speed = 2;
        yield return new WaitForSeconds(.4f);
        speed = 5;
        myAnim.Play("Trash canSeePlayer");
    }


}
