using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class exitButton : MonoBehaviour
{

    public GameObject ExitScreen;

    public static exitButton instance;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && (ExitScreen.active == false))
        {
            FindObjectOfType<audioManager>().Play("Button Press");
            ExitScreen.active = true;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && (ExitScreen.active == true))
        {
            FindObjectOfType<audioManager>().Play("Button Press");
            ExitScreen.active = false;
        }


        if (Input.GetButtonDown("Submit") && (ExitScreen.active == true))
        {
            FindObjectOfType<audioManager>().Play("Button Press");
            Application.Quit();
        }
    }
}
