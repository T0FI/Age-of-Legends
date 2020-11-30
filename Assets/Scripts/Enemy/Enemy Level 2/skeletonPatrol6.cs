using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletonPatrol6 : MonoBehaviour
{
    //https://www.youtube.com/watch?v=aRxuKoJH9Y0&ab_channel=Blackthornprod
    public float speed;
    GameObject skeletonMonster;
    public int eHealth;
    int heroADamage;

    [SerializeField]
    GameObject attackHitbox;

    private bool movingRight = true;

    public Transform groundChecker;

    bool isAttacking = false;


    Animator myAnim;


    void Start()
    {
        skeletonMonster = GameObject.Find("Skeleton Monster6");

        myAnim = GetComponent<Animator>();

        attackHitbox.SetActive(false);


    }


    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.tag == "Player" && isAttacking == false)
        {
            isAttacking = true;
            myAnim.Play("Skeleton Attack");
            StartCoroutine(Attacking());



        }

        if (other.gameObject.tag == "attackHitBox")
        {
            myAnim.Play("Skeleton TakeHit");
            eHealth -= heroDamage.heroADamage;
            StartCoroutine(attacked());


            print(heroDamage.heroADamage);
            print(eHealth);


        }
    }

    IEnumerator Attacking()
    {
        speed = 0;
        yield return new WaitForSeconds(0.25f);
        attackHitbox.active = true;
        yield return new WaitForSeconds(0.1f);
        attackHitbox.active = false;
        yield return new WaitForSeconds(1f);
        isAttacking = false;
        myAnim.Play("Skeleton Walk");
        speed = 2;

    }



    IEnumerator attacked()
    {
        FindObjectOfType<audioManager>().Play("Enemy TakeHit");
        speed = 0;
        yield return new WaitForSeconds(0.2f);
        speed = 2;

        if (eHealth > 0)
        {
            myAnim.Play("Skeleton Walk");
        }
        else
        {
            myAnim.Play("Skeleton Death");
        }
    }

    void axeSwingSound()
    {
        FindObjectOfType<audioManager>().Play("Skeleton Attack");
    }


    void Update()
    {

        if (eHealth <= 0)
        {
            myAnim.Play("Skeleton Death");
            speed = 0;
            skeletonMonster.GetComponent<BoxCollider2D>().enabled = false;
            skeletonMonster.GetComponent<CapsuleCollider2D>().enabled = false;

        }

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundChecker.position, Vector2.down, 0.5f);

        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);

                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }


}

