using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level2GoalScript : MonoBehaviour
{
    // Animator myAnim;
    public Level2to3Transition loadLevel;

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
        SceneManager.LoadScene(6);

    }
}
