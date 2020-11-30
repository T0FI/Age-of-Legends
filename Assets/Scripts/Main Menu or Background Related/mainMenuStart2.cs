using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuStart2 : MonoBehaviour
{

    public Animator transition;

    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FindObjectOfType<audioManager>().Play("Button Press");
            LoadNextLevel();
            //DestroyTransition();
            //Destroy(GameObject.FindWithTag("tempTransition"));
        }
    }

    public void LoadNextLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveSciene().buildIndex + 1);
        //SceneManager.LoadScene(1);

        //StartCoroutine(Transition(SceneManager.GetActiveScene().buildIndex + 1));
        StartCoroutine(Transition(1));

    }

    IEnumerator Transition(int levelIndex)
    {
        //Play animation
        transition.SetTrigger("Start");
        //Wait
        yield return new WaitForSeconds(2);
        //Load Scene
        SceneManager.LoadScene(levelIndex);
        
    }


}
