using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class defeatButtons : MonoBehaviour
{

    public void playAgain()
    {
        FindObjectOfType<audioManager>().Play("Button Press");
        SceneManager.LoadScene(2);
    }

    public void mainMenu()
    {
        FindObjectOfType<audioManager>().Play("Button Press");
        SceneManager.LoadScene(0);
    }
}
