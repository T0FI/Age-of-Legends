using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossDefeated : MonoBehaviour
{

    int bossHealth;
    public bool isVictory = false;
    GameObject Image;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Image = GameObject.Find("Image");
        animator = Image.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        bossHealth = GetComponent<bossScript>().bossHealth;

        if (animator == null)
        {
            print("no anim found");
        }

        Victory();

    }


    void Victory()
    {
        if (bossHealth <= 0)
        {
            isVictory = true;
            StartCoroutine(VictoryTransition());
        }
    }

    public IEnumerator VictoryTransition()
    {
        yield return new WaitForSeconds(2f);
        animator.SetBool("Victory", isVictory);

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(8);


    }
}
