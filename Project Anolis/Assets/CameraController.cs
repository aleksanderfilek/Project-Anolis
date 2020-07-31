using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform cameraControllerTransform;
    [SerializeField] private Transform cameraTransform;

    [SerializeField] private float rotatingSpeed = 100;
    [SerializeField] private float zoomSpeed = 1;

    enum MovementMode
    {
        Free,
        KeepPoles
    }

    [SerializeField] private MovementMode currentMovementMode;

    void Update()
    {
        switch (currentMovementMode)
        {
            case MovementMode.Free:
                MakeFreeMovement();
            break;

            case MovementMode.KeepPoles:
                MakeKeepPolesMovement();
            break;
        }
    }

    private void MakeFreeMovement()
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

    private void MakeKeepPolesMovement()
    {
        if (Input.GetKey("w") && UnityEditor.TransformUtils.GetInspectorRotation(cameraControllerTransform.transform).x <= 90)
            cameraControllerTransform.Rotate(new Vector3(1, 0, 0) * Time.deltaTime * rotatingSpeed);
        if (Input.GetKey("s") && UnityEditor.TransformUtils.GetInspectorRotation(cameraControllerTransform.transform).x >= -90)
            cameraControllerTransform.Rotate(new Vector3(-1, 0, 0) * Time.deltaTime * rotatingSpeed);
        if (Input.GetKey("a"))
            cameraControllerTransform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * rotatingSpeed, Space.World);
        if (Input.GetKey("d"))
            cameraControllerTransform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * rotatingSpeed, Space.World);
    }

}