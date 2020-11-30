using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartScript : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<audioManager>().Play("Heart Pickup");
            Destroy(this.gameObject);


        }
    }
}
