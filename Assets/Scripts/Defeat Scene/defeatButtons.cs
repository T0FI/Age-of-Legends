using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class defeatButtons : MonoBehaviour
{

    public void playAgain()
    {
        SceneManager.LoadScene(2);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
