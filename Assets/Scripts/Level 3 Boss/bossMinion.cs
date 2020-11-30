using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMinion : MonoBehaviour
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
    public Transform playertest;
    Transform Player;
    Transform Player2;
    Transform Player3;
    Transform Player4;
    Transform Player5;

    public GameObject attackHitBox;

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

    public bool alive = true;

    Rigidbody2D enemyRB;
    Animator myAnim;
    GameObject Boss;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(10, 10);
        Physics2D.IgnoreLayerCollision(10, 11);
        Physics2D.IgnoreLayerCollision(10, 9);

        Boss = GameObject.Find("Boss");
        bossScript bossScript = Boss.GetComponent<bossScript>();
        Player = bossScript.Player;
        Player2 = bossScript.Player2;
        Player3 = bossScript.Player3;
        Player4 = bossScript.Player4;
        Player5 = bossScript.Player5;

        Hero1 = Player.gameObject;
        Hero2 = Player2.gameObject;
        Hero3 = Player3.gameObject;
        Hero4 = Player4.gameObject;
        Hero5 = Player5.gameObject; 

        this.enemyRB = this.GetComponent<Rigidbody2D>();
        this.myAnim = this.GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        checkingGround = Physics2D.OverlapCircle(groundChecker.position, circleRadius, groundLayer);
        checkingWall = Physics2D.OverlapCircle(wallChecker.position, circleRadius, groundLayer);
        isGrounded = Physics2D.OverlapBox(groundCheck2.position, boxSize, 0, groundLayer);
        canSeePlayer = Physics2D.OverlapBox(transform.position, lineOfSight, 0, playerLayer);


        AnimationController();

        if (!canSeePlayer && isGrounded)
        {
            Petrolling();
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
            FindObjectOfType<audioManager>().Play("Slime Jump");
        }

        else if (isGrounded && (Hero2.active == true))
        {
            enemyRB.AddForce(new Vector2(distanceFromPlayer2, jumpHeight), ForceMode2D.Impulse);
            FindObjectOfType<audioManager>().Play("Slime Jump");
        }
        else if (isGrounded && (Hero3.active == true))
        {
            enemyRB.AddForce(new Vector2(distanceFromPlayer3, jumpHeight), ForceMode2D.Impulse);
            FindObjectOfType<audioManager>().Play("Slime Jump");
        }
        else if (isGrounded && (Hero4.active == true))
        {
            enemyRB.AddForce(new Vector2(distanceFromPlayer4, jumpHeight), ForceMode2D.Impulse);
            FindObjectOfType<audioManager>().Play("Slime Jump");
        }
        else if (isGrounded && (Hero5.active == true))
        {
            enemyRB.AddForce(new Vector2(distanceFromPlayer5, jumpHeight), ForceMode2D.Impulse);
            FindObjectOfType<audioManager>().Play("Slime Jump");
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
        else if (distanceFromPlayer > 0 && !movingRight && (Hero1.active == false))
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
        
        yield return new WaitForSeconds(0f);
        enemyRB.AddForce(new Vector2(0, 20));
        yield return new WaitForSeconds(.1f);
        enemyRB.AddForce(new Vector2(0, 0));

    }


    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "attackHitBox")
        {
            if (eHealth >= 1)
            {
                StartCoroutine(Attacked());
                FindObjectOfType<audioManager>().Play("Enemy TakeHit");
                myAnim.Play("Minion TakeHit");
                eHealth -= heroDamage.heroADamage;
                print(eHealth);
                
            }

            StartCoroutine(CheckHealth());
        }

        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Attack());
        }
    }


    IEnumerator Attack()
    {
        if (eHealth >= 1)
          {
            myAnim.Play("Minion Attack");
            yield return new WaitForSeconds(.5f);
            myAnim.Play("Minion Walk");
          }
    }

    IEnumerator Walk()
    {
        this.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(.3f);
        myAnim.Play("Minion Walk");
    }

    IEnumerator Attacked()
    {
        if (eHealth >= 1)
        {
            speed = 2;
            yield return new WaitForSeconds(.4f);
            speed = 5;

        }
        yield return new WaitForSeconds(.2f);
    }

    IEnumerator CheckHealth()
    {
        
        if (eHealth <= 0)
        {
            speed = 0;
            alive = false;
            myAnim.SetBool("alive", alive);
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            yield return new WaitForSeconds(.4f);
            Destroy(this.gameObject);
        }

        
    }
}
