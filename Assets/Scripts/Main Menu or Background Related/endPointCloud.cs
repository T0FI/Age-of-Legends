using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endPointCloud : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Cloud")
        {
            Destroy(other.gameObject);
        }
    }
}