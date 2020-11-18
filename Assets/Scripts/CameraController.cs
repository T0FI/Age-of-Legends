using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform CameraFollower; //Follow the camera
    public float Smoothing; //Effect

    Vector3 Offset;
    float LowestPoint;

    // Start is called before the first frame update
    void Start()
    {
        Offset = transform.position - CameraFollower.position;

        LowestPoint = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 CameraPositon = CameraFollower.position + Offset;

        transform.position = Vector3.Lerp(transform.position,CameraPositon,Smoothing *Time.deltaTime);

        transform.position = new Vector3(transform.position.x, LowestPoint, transform.position.z);
    }
}
