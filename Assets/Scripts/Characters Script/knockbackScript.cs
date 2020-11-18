using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockbackScript : MonoBehaviour
{
    //https://www.youtube.com/watch?v=ahadN8aGvXg&ab_channel=PekkeDev

    public static knockbackScript instance;
    private Rigidbody2D myRB;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public IEnumerator Knockback(float knockbackDuration, float knockbackPower, Transform obj)
    {
        float timer = 0;

        while (knockbackDuration > timer)
        {
            timer += Time.deltaTime;
            Vector2 direction = (obj.transform.position = this.transform.position).normalized;
            myRB.AddForce(-direction * knockbackPower);
        }

        yield return 0;
    }

}
