using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossWalk : StateMachineBehaviour
{
    //https://www.youtube.com/watch?v=AD4JIXQDw0s&t=331s&ab_channel=Brackeys


    public float speed = 3.5f;
    public float attackRange = 8.9f;

    Transform Player;
    Rigidbody2D rb;
    bossScript boss;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<bossScript>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.FlipTowardsThePlayer();
        Vector2 target = new Vector2(Player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        if (Vector2.Distance(Player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("Boss Attack1");
        }

    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Boss Attack1");
    }


}
