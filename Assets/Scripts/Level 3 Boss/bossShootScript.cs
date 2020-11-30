using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossShootScript : MonoBehaviour
{


    public GameObject bullet;
    public GameObject ShootingPos;


    void Start()
    {

    }

    
    void Update()
    {

    }


    void ShootStage2()
    {
        FindObjectOfType<audioManager>().Play("Boss Shoot");
        Instantiate(bullet, ShootingPos.transform.position, Quaternion.identity);
    }
}
