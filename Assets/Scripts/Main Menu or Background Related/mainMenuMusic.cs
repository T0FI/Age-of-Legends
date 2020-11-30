using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class mainMenuMusic : MonoBehaviour
{

    public static mainMenuMusic instance;

    // Start is called before the first frame update
    void Awake()
    {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
