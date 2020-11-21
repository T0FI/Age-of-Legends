using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeAttackRange : MonoBehaviour
{
    Animator animator;
    bossWalk bossWalk;

    private void Start()
    {
       // bossWalk = animator.GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           // bossWalk.SetTrigger("Boss Attack1");
        }
    }


}
