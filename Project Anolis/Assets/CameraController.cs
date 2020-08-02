using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform cameraControllerTransform;
    [SerializeField] private Transform cameraTransform;

    [SerializeField] private float rotatingSpeed = 100f;
    [SerializeField] private float zoomSpeed = 25f;

    [SerializeField] private MovementMode currentMovementMode;

    void Update()
    {
        MakeMovement();
    }

    private void MakeMovement()
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

    enum MovementMode
    {
        Free,
        KeepPoles
    }

    private void MakeFreeMovement()
    {
        if (Input.GetKey("w"))
            rotateCameraInDirection(CameraRotateDirection.up);

        if (Input.GetKey("s"))
            rotateCameraInDirection(CameraRotateDirection.down);

        if (Input.GetKey("a"))
            rotateCameraInDirection(CameraRotateDirection.left);

        if (Input.GetKey("d"))
            rotateCameraInDirection(CameraRotateDirection.right);

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            ZoomIn();

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            ZoomOut();
    }

    private void MakeKeepPolesMovement()
    {
        if (Input.GetKey("w") && isCameraRotationSmallerThanUpperBound())
            rotateCameraInDirection(CameraRotateDirection.up);

        if (Input.GetKey("s") && isCameraRotationGreaterThanLowerBound())
            rotateCameraInDirection(CameraRotateDirection.down);

        if (Input.GetKey("a"))
            rotateCameraInDirection(CameraRotateDirection.left, Space.World);

        if (Input.GetKey("d"))
            rotateCameraInDirection(CameraRotateDirection.right, Space.World);

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            ZoomIn();

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            ZoomOut();
    }

    private void rotateCameraInDirection(Vector3 direction, Space relativeTo = Space.Self)
    {
        cameraControllerTransform.Rotate(direction * Time.deltaTime * rotatingSpeed, relativeTo);
    }

    static class CameraRotateDirection
    {
        public static readonly Vector3 up = new Vector3(1, 0, 0);
        public static readonly Vector3 down = new Vector3(-1, 0, 0);
        public static readonly Vector3 right = new Vector3(0, -1, 0);
        public static readonly Vector3 left = new Vector3(0, 1, 0);
    }

    private bool isCameraRotationSmallerThanUpperBound()
    {
        //sould be rotationEulerAngles.z == 180f, but comparing floats is not a good idea
        //rotationEulerAngles.z can have values 180f and 0f, therefore conidtion > 90f was chosen
        var rotationAngles = cameraControllerTransform.localEulerAngles;
        return rotationAngles.z > 90f ? rotationAngles.x >= 270f : true;
    }

    private bool isCameraRotationGreaterThanLowerBound()
    {
        //sould be rotationEulerAngles.z == 180f, but comparing floats is not a good idea
        //rotationEulerAngles.z can have values 180f and 0f, therefore conidtion > 90f was chosen
        var rotationAngles = cameraControllerTransform.localEulerAngles;
        return rotationAngles.z > 90f ? rotationAngles.x <= 90f : true;
    }
    private void ZoomIn()
    {
        cameraTransform.localPosition += new Vector3(0, 0, 1) * zoomSpeed * Time.deltaTime;
    }

    private void ZoomOut()
    {
        cameraTransform.localPosition += new Vector3(0, 0, -1) * zoomSpeed * Time.deltaTime;
    }

}