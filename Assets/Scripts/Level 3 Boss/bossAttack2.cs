using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAttack2 : MonoBehaviour
{

    playerDetect dPlayer;
    Animator animator;
    public float speed;
    bossWalk bossW;
    bossScript bossS;

    bool isPlayerRight;
    public bool isBossRight;

    public GameObject MArenaPosition;

    public float forceMult = 200;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

        dPlayer = GetComponentInChildren<playerDetect>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {


       // isPlayerRight = dPlayer.isRight;

        if (Input.GetKeyDown(KeyCode.L))
        {
            
            StartCoroutine(BossShootR());

        }

    }

    void Shoot()
    {
        Flip();
        animator.Play("Boss Move");
        rb.AddForce(transform.right * forceMult);
        StartCoroutine(BossShootR());
    }


    void Flip()
    {
        transform.Rotate(0, 180, 0);
    }

    IEnumerator BossShootR()
    {
        
        animator.Play("Boss Move");
        rb.AddForce(transform.right * forceMult);
        yield return new WaitForSeconds(.5f);
        animator.Play("Boss Shoot");
        yield return new WaitForSeconds(4.5f);

        Flip();
        animator.Play("Boss Move");
        rb.AddForce(transform.right * forceMult);
        yield return new WaitForSeconds(.5f);
        animator.Play("Boss Shoot");
        yield return new WaitForSeconds(4.5f);

        animator.Play("Boss Move");
        transform.position = MArenaPosition.transform.position;
        yield return new WaitForSeconds(.4f);
        animator.Play("Boss Idle2");

        yield return new WaitForSeconds(5f);
        
        StartCoroutine(BossShootR());

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
