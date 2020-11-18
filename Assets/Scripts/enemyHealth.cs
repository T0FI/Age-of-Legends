using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    GameObject Enemy1;
    public int eHealth;
    int heroADamage;

    void Start()
    {
        
        Enemy1 = GameObject.Find("EyeBall");
        heroADamage = heroDamage.heroADamage;
        eHealth = 230;

        print(heroADamage);
    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "attackHitBox")
        {
            eHealth -= heroADamage;
            checkHealth();
            print(heroADamage);
            print(eHealth);


        }
    }

    void checkHealth()
    {
        if (eHealth <= 0)
        {
            Enemy1.active = false;
        }
    }
}
