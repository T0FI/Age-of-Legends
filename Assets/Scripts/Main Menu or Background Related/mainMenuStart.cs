using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuStart : MonoBehaviour
{

    public Animator transition;

    public float transitionTime = 1f;

    // Update is called once per frame

    public void changeMenuScene(string sceneName)
    {
        LoadNextLevel();
       // Application.LoadLevel(sceneName);
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
        Destroy(GameObject.FindWithTag("tempTransition"));
    }


}
