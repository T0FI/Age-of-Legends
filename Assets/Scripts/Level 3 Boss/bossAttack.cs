using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAttack : MonoBehaviour
{

    playerDetect dPlayer;
    Animator animator;
    public float speed;
    bossWalk bossW;
    bossScript bossS;

    int bossHealth;
    bool isPlayerRight;
    public bool isBossRight;

    public GameObject MArenaPosition;

    GameObject AttackR;
    GameObject AttackL;
    GameObject Boss;
    Animator animAR;
    Animator animAL;


    public float forceMult = 200;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

        dPlayer = GetComponentInChildren<playerDetect>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        

        AttackL = GameObject.Find("Attack Position L");
        AttackR = GameObject.Find("Attack Position R");
        Boss = GameObject.Find("Boss");

        animAR = AttackR.GetComponent<Animator>();
        animAL = AttackL.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        bossHealth = GetComponent<bossScript>().bossHealth;
        
       // isPlayerRight = dPlayer.isRight;

    }

    void Shoot()
    {
        Flip();
        animator.Play("Boss Move");
        rb.AddForce(transform.right * forceMult);
        StartCoroutine(BossStage2());
    }


    void Flip()
    {
        transform.Rotate(0, 180, 0);
    }

    public IEnumerator BossStage2()
    {
        print("Boss Stage 2 Playing");
        Boss.GetComponent<CapsuleCollider2D>().enabled = false;
        animator.Play("Boss Move");
        rb.AddForce(transform.right * forceMult);
        yield return new WaitForSeconds(.5f);
        animator.Play("Boss Shoot");
        yield return new WaitForSeconds(2.9f);

        Flip();
        animator.Play("Boss Move");
        rb.AddForce(transform.right * forceMult);
        yield return new WaitForSeconds(.5f);
        animator.Play("Boss Shoot");
        yield return new WaitForSeconds(2.9f);

        Flip();
        animator.Play("Boss Move");
        rb.AddForce(transform.right * forceMult);
        yield return new WaitForSeconds(.5f);
        animator.Play("Boss Shoot");
        yield return new WaitForSeconds(2.9f);

        Boss.GetComponent<CapsuleCollider2D>().enabled = true;
        animator.Play("Boss Move");
        transform.position = MArenaPosition.transform.position;
        yield return new WaitForSeconds(.4f);
        animator.Play("Boss Idle2");

        yield return new WaitForSeconds(3f);

        if (bossHealth > 4000)
        {
            StartCoroutine(BossStage2());
        }
    }

    public IEnumerator BossStage3()
    {

        print("Boss Stage 3 Playing");
        Boss.GetComponent<CapsuleCollider2D>().enabled = false;
        animator.Play("Boss Move");
        rb.AddForce(transform.right * forceMult);
        yield return new WaitForSeconds(.5f);
        animator.Play("Boss Shoot");
        yield return new WaitForSeconds(2.9f);
        animator.Play("Boss Spawn Minions");
        animAL.Play("minionSpawn");
        animAR.Play("minionSpawn");
        yield return new WaitForSeconds(.6f);

        Flip();
        animator.Play("Boss Move");
        rb.AddForce(transform.right * forceMult);
        yield return new WaitForSeconds(.5f);
        animator.Play("Boss Shoot");
        yield return new WaitForSeconds(2.9f);
        animator.Play("Boss Spawn Minions");
        animAL.Play("minionSpawn");
        animAR.Play("minionSpawn");
        yield return new WaitForSeconds(.6f);

        Flip();
        animator.Play("Boss Move");
        rb.AddForce(transform.right * forceMult);
        yield return new WaitForSeconds(.5f);
        animator.Play("Boss Shoot");
        yield return new WaitForSeconds(2.9f);
        animator.Play("Boss Spawn Minions");
        animAL.Play("minionSpawn");
        animAR.Play("minionSpawn");
        yield return new WaitForSeconds(.6f);

        Boss.GetComponent<CapsuleCollider2D>().enabled = true;
        animator.Play("Boss Move");
        transform.position = MArenaPosition.transform.position;
        yield return new WaitForSeconds(.4f);
        animator.Play("Boss Idle2");

        yield return new WaitForSeconds(3f);

        if (bossHealth > 0)
        {
            StartCoroutine(BossStage3());
        }   

    }



    void checkDirection()
    {
        if (transform.lossyScale.x > 0)
        {
            isBossRight = true;
            float fx = transform.localScale.x;
                
            fx *= -1f;
            if(isBossRight == isPlayerRight)
            {
                transform.localScale = new Vector3(fx, transform.localScale.y, transform.localScale.z);
            }
        }
        else if (transform.lossyScale.x < 0)
        {
            isBossRight = false;
            float fx = transform.localScale.x;

            fx *= -1f;
            if (isBossRight == isPlayerRight)
            {
                transform.localScale = new Vector3(fx, transform.localScale.y, transform.localScale.z);
            }
        }
    }

    IEnumerator AttackRight()
    {
        yield return new WaitForSeconds(0.5f);
        animator.Play("Boss Shoot");
    }


}
