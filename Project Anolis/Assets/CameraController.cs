using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform cameraControllerTransform;
    [SerializeField] private Transform cameraTransform;

    [SerializeField] private float rotatingSpeed = 100;
    [SerializeField] private float zoomSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
            cameraControllerTransform.Rotate(new Vector3(1, 0, 0) * Time.deltaTime * rotatingSpeed);
        if (Input.GetKey("s"))
            cameraControllerTransform.Rotate(new Vector3(-1, 0, 0) * Time.deltaTime * rotatingSpeed);
        if (Input.GetKey("a"))
            cameraControllerTransform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * rotatingSpeed);
        if (Input.GetKey("d"))
            cameraControllerTransform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * rotatingSpeed);
    }
}