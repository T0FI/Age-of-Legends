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

    Animator animator;

    public bool isFlipped = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

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
