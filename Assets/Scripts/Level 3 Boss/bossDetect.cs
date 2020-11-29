using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossDetect : MonoBehaviour
{
    public Transform Boss;

    public bool isRight = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        detect();
    }

    public void detect()
    {
        if (transform.position.x < Boss.position.x)
        {
            isRight = true;
            
        }
        else if (transform.position.x > Boss.position.x)
        {
            isRight = false;
        }

        
        //print(isRight);
    }
}
