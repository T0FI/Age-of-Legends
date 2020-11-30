using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletImpact : MonoBehaviour
{

    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<audioManager>().Play("Boss Bullet Explode");
            animator.Play("Boss Bullet Impact");
            this.GetComponent<CircleCollider2D>().enabled = false;
            StartCoroutine(Destroy());
        }
    }


    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(.9f);
        Destroy(gameObject);
    }


}
