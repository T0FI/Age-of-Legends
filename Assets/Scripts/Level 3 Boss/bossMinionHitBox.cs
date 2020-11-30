using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMinionHitBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(13, 12);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
