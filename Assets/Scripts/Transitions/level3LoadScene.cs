using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level3LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loadLevel3());
    }

    IEnumerator loadLevel3()
    {

        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(7);

    }
}
