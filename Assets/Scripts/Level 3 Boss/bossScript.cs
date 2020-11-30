using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossScript : MonoBehaviour
{
    //https://www.youtube.com/watch?v=AD4JIXQDw0s&t=331s&ab_channel=Brackeys

    public Transform Player;
    public Transform Player2;
    public Transform Player3;
    public Transform Player4;
    public Transform Player5;

    public GameObject Hero1;
    public GameObject Hero2;
    public GameObject Hero3;
    public GameObject Hero4;
    public GameObject Hero5;

    public GameObject AttackR;
    public GameObject AttackL;

    public GameObject Boss;

    int maxHealth = 10000;
    public int bossHealth;
    public bossHealth healthBar;
    public bossAttack bossA;

    public bool isAlive = true;
    public bool Stage2 = false;
    public bool Stage3 = false;
    public bool Test = false;

    Animator animator;

    public bool isFlipped = false;

    private void Start()
    {

        bossHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        animator = GetComponent<Animator>();
    }

    private void Update()
    {

        if (bossHealth <= 6000)
        {
            StopCoroutine(Boss.GetComponent<bossAttack>().BossStage2());
        }

        if (bossHealth <= 0)
        {
            isAlive = false;
            animator.SetBool("isAlive", isAlive);
            StopAllCoroutines();
            StopCoroutine(Boss.GetComponent<bossAttack>().BossStage2());
            StopCoroutine(Boss.GetComponent<bossAttack>().BossStage3());
            Boss.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            Boss.GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "attackHitBox")
        {
            FindObjectOfType<audioManager>().Play("Boss TakeHit");
            bossHealth -= heroDamage.heroADamage;
            healthBar.SetHealth(bossHealth);
            StartCoroutine(Attacked());
        }
    }

    IEnumerator Attacked()
    {
        animator.Play("Boss TakeHit");
        yield return new WaitForSeconds(.1f);
        checkHealth();
        if (bossHealth > 6000)
        {
            animator.Play("Boss Attack1");
        }
        else
        {
            animator.Play("Boss Idle2");
        }
    }

    void checkHealth()
    {
        
        if (bossHealth <= 6000)
        {
            Stage2 = true;
        }

        if (bossHealth <= 4000)
        {
            Stage2 = false;
            Stage3 = true;
        }

        if (bossHealth <= 0)
        {
            StopAllCoroutines();
            StopCoroutine(Boss.GetComponent<bossAttack>().BossStage2());
            StopCoroutine(Boss.GetComponent<bossAttack>().BossStage3());
            isAlive = false;
            animator.SetBool("isAlive", isAlive);
            Boss.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            Boss.GetComponent<CapsuleCollider2D>().enabled = false;
        }

        if (Stage2 == true && Test == false)
        {
            StartCoroutine(Boss.GetComponent<bossAttack>().BossStage2());
            Test = true;
            print("Starting Stage 2");
        }

        if (Stage3 == true && Test == true)
        {
            Stage2 = false;
            StopAllCoroutines();
            StopCoroutine(Boss.GetComponent<bossAttack>().BossStage2());
            StartCoroutine(Boss.GetComponent<bossAttack>().BossStage3());
            Test = false;
            print("Starting Stage 3");
        }


        
    }

    void bossDeathSound()
    {
        FindObjectOfType<audioManager>().Play("Boss Death");
    }

    public void FlipTowardsThePlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if(transform.position.x > Player.position.x && isFlipped && (Hero1.active == true))
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < Player.position.x && !isFlipped && (Hero1.active == true))
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
        else if (transform.position.x > Player2.position.x && isFlipped && (Hero2.active == true))
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < Player2.position.x && !isFlipped && (Hero2.active == true))
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
        else if (transform.position.x > Player3.position.x && isFlipped && (Hero3.active == true))
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < Player3.position.x && !isFlipped && (Hero3.active == true))
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
        else if (transform.position.x > Player4.position.x && isFlipped && (Hero4.active == true))
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < Player4.position.x && !isFlipped && (Hero4.active == true))
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
        else if (transform.position.x > Player5.position.x && isFlipped && (Hero5.active == true))
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < Player5.position.x && !isFlipped && (Hero5.active == true))
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }

    }  
}
