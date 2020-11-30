using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMinion : MonoBehaviour
{
    public GameObject minion;
    public GameObject spawnPos;


    void Start()
    {

    }


    void Update()
    {

      
    }


    void spawnMinions()
    {
        GameObject minions;
        
        minions = Instantiate(minion, spawnPos.transform.position, Quaternion.identity) as GameObject;
        minions.GetComponent<Rigidbody2D>();
        minions.GetComponent<Animator>();
    }
}
