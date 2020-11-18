using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1to2Transition : MonoBehaviour
{

    Animator myAnim;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();

    }

    public void startTransition()
    {
        myAnim.Play("Level 2 Transition");
    }
}
