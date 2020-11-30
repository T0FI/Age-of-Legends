using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{

    public float speed;

    private Transform bPosL;
    private Transform bPosR;

    private Vector2 targetR;
    private Vector2 targetL;
    private Vector2 target;


    public bossDetect bossDetect;
    Rigidbody2D rb;
    public bool isRight;

    private float velocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bPosL = GameObject.FindGameObjectWithTag("bPosL").transform;
        bPosR = GameObject.FindGameObjectWithTag("bPosR").transform;
        targetR = new Vector2(bPosR.position.x, bPosR.position.y);
        targetL = new Vector2(bPosL.position.x, bPosL.position.y);
        
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AttackPosR")
        {
            Flip();
        }
        else if (collision.gameObject.tag == "AttackPosL")
        {
            
        }

        if (collision.gameObject.tag == "Player")
        {
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    void Update()
    {

        rb.AddForce(transform.right * 100);



        StartCoroutine(DestroyMiss());
    }
    
    void checkBoss()
    {
        
        
    }


    IEnumerator DestroyMiss()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

}
