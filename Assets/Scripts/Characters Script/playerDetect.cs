using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDetect : MonoBehaviour
{
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

    void detect()
    {
        if (transform.position.x < Player.position.x && (Hero1.active == true))
        {
            isRight = true;
            
        }
        else if (transform.position.x > Player.position.x)
        {
            isRight = false;
        }

        if (transform.position.x < Player2.position.x && (Hero2.active == true))
        {
            isRight = true;
        }
        else if (transform.position.x > Player2.position.x)
        {
            isRight = false;
        }

        if (transform.position.x < Player3.position.x && (Hero3.active == true))
        {
            isRight = true;
        }
        else if (transform.position.x > Player3.position.x)
        {
            isRight = false;
        }

        if (transform.position.x < Player4.position.x && (Hero4.active == true))
        {
            isRight = true;
        }
        else if (transform.position.x > Player4.position.x)
        {
            isRight = false;
        }

        if (transform.position.x < Player5.position.x && (Hero5.active == true))
        {
            isRight = true;
        }
        else if (transform.position.x > Player5.position.x)
        {
            isRight = false;
        }
      //  print(isRight);
    }
}
