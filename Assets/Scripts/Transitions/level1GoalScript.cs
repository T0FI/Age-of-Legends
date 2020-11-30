using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level1GoalScript : MonoBehaviour
{
    // Animator myAnim;
    public Level1to2Transition loadLevel;

    // Start is called before the first frame update
    void Start()
    {

    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            loadLevel.startTransition();
            StartCoroutine(nextLevel());
        }

    }

    IEnumerator nextLevel()
    {

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(4);

    }
}
