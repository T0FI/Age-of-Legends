using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingNPCScript : MonoBehaviour
{
    Animator animation;
    Rigidbody2D rb2d;


    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Run()
    {
        animation.Play("King run");
        rb2d.velocity = new Vector2(-2f, 0f) * speed;
    }
}
