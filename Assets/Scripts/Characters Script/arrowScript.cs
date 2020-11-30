using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour
{

    public float dieTime;
    public GameObject arrowDieEffect;


    void Start()
    {
        


        StartCoroutine(Timer());
    }


    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.name != "Player")
        {
            FindObjectOfType<audioManager>().Play("Arrow Collision");
            Die();

        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(dieTime);
    }


    void Die()
    {
        if(arrowDieEffect != null)
        {
           Instantiate(arrowDieEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
