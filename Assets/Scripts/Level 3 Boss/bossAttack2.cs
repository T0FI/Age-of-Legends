using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAttack2 : MonoBehaviour
{
    public GameObject ARPosition;
    public Transform APositionR;
    Animator animator;
    public float speed;
    

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        }
    }

    void AttackRight()
    {
        animator.Play("Boss RMove");
        
    }
}
