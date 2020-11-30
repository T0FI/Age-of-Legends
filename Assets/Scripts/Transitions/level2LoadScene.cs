using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level2LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loadLevel2());
    }

    IEnumerator loadLevel2()
    {

        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(5);

    }
}
