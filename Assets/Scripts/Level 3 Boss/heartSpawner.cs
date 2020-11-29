using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] Clouds;

    [SerializeField]
    float cloudSpawnInterval;

    [SerializeField]
    GameObject endCloudSpawn;

    Vector3 CloudStartPosition;

    // Start is called before the first frame update
    void Start()
    {

        CloudStartPosition = transform.position;

        Invoke("SpawnAttempt", cloudSpawnInterval);


    }

    void CloudSpawner()
    {
        int RandomCloud = UnityEngine.Random.Range(0, 1);
        GameObject clouds = Instantiate(Clouds[RandomCloud]);

        clouds.transform.position = CloudStartPosition;

    }

    void SpawnAttempt()
    {

        CloudSpawner();
        Invoke("SpawnAttempt", cloudSpawnInterval);

    }

}