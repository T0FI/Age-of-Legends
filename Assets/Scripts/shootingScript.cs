using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class shootingScript : MonoBehaviour
{
    public float shootSpeed, shootTimer;
    public Transform shootPos;
    public GameObject arrow;

    private bool isShooting;

    void Start()
    {
        isShooting = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isShooting)
        {
            //Shoot
            StartCoroutine(Shoot());
        }    
    }

    IEnumerator Shoot()
    {
        int direction()
        {
            if(transform.localScale.x < 0f)
            {
                return -1;
            }
            else
            {
                return +1;
            }
        }

        isShooting = true;
        GameObject newArrow = Instantiate(arrow, shootPos.position, Quaternion.identity);
        newArrow.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * direction() * Time.fixedDeltaTime, 0f);
        newArrow.transform.localScale = new Vector2(newArrow.transform.localScale.x * direction(), newArrow.transform.localScale.y);

        yield return new WaitForSeconds(shootTimer);
        isShooting = false;

    }
}
