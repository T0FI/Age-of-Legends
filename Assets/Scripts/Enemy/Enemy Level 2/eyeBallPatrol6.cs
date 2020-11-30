using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeBallPatrol6 : MonoBehaviour
{
    //https://www.youtube.com/watch?v=aRxuKoJH9Y0&ab_channel=Blackthornprod
    public float speed;
    GameObject eyeBallEnemy;
    public int eHealth;
    int heroADamage;


    private bool movingRight = true;

    public Transform groundChecker;



    Animator myAnim;


    void Start()
    {
        eyeBallEnemy = GameObject.Find("EyeBall Monster3");

        myAnim = GetComponent<Animator>();


    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "attackHitBox")
        {

            eHealth -= heroDamage.heroADamage;
            StartCoroutine(checkHealth());
            StartCoroutine(attacked());



            print(heroDamage.heroADamage);
            print(eHealth);


        }
    }


    IEnumerator attacked()
    {
        FindObjectOfType<audioManager>().Play("Enemy TakeHit");
        if (eHealth > 0)
        {
            myAnim.Play("eyeBall Monster TakeHit");
            speed = 0;
            yield return new WaitForSeconds(0.2f);
            speed = 2;
            myAnim.Play("EyeMonster walk");

        }
    }
    IEnumerator checkHealth()
    {

        if (eHealth <= 0)
        {
            myAnim.Play("eyeBall Monster Death");
            speed = 0;
            eyeBallEnemy.GetComponent<CircleCollider2D>().enabled = false;
            yield return new WaitForSeconds(1f);

            eyeBallEnemy.active = false;
        }
    }

    void Update()
    {
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
