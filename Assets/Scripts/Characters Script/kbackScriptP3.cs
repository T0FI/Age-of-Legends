using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kbackScriptP3 : MonoBehaviour
{

    //https://www.youtube.com/watch?v=-dMtWZsjX6g&ab_channel=GucioDevs

    public static kbackScriptP3 instance;

    Rigidbody2D myRB;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Knockback(float knockbackDuration, float knockbackPower, Vector3 knockbackDirection)
    {

        float timer = 0;

        while (knockbackDuration > timer)
        {
            timer += Time.deltaTime;
            myRB.AddForce(new Vector3(knockbackDirection.x, -knockbackDirection.y + knockbackPower, transform.position.z));  
            
        }

        yield return 0;
    }
}
