using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform cameraControllerTransform;
    [SerializeField] private Transform cameraTransform;

    [SerializeField] private float rotatingSpeed = 100f;
    [SerializeField] private float zoomSpeed = 25f;

    [SerializeField] private float planetSurfaceHeight = 5f; 

    private float _rotationVertical = 0f;
    private float _rotationHorizontal = 0f;
    private float _zoom = 0f;

    void Update()
    {
        _rotationVertical = Input.GetAxis("Vertical");
        _rotationHorizontal = Input.GetAxis("Horizontal");
        _zoom = Input.GetAxis("Mouse ScrollWheel");

        MakeMovement();
    }

    private void MakeMovement()
    {
        if (_rotationVertical > 0 && isWithinUpperBound())
            rotateCamera(CameraRotateDirection.up, amount: Mathf.Abs(_rotationVertical));

        if (_rotationVertical < 0 && isWithinLowerBound())
            rotateCamera(CameraRotateDirection.down, amount: Mathf.Abs(_rotationVertical));

        if (_rotationHorizontal < 0)
            rotateCamera(CameraRotateDirection.left, amount: Mathf.Abs(_rotationHorizontal), relativeTo: Space.World);

        if (_rotationHorizontal > 0)
            rotateCamera(CameraRotateDirection.right, amount: Mathf.Abs(_rotationHorizontal), relativeTo: Space.World);

        if (_zoom > 0f)
            ZoomIn();

        if (_zoom < 0f)
            ZoomOut();
    }

    private bool isWithinUpperBound()
    {
        //sould be rotationEulerAngles.z == 180f, but comparing floats is not a good idea
        //rotationEulerAngles.z can have values 180f and 0f, therefore conidtion > 90f was chosen
        var rotationAngles = cameraControllerTransform.localEulerAngles;
        return rotationAngles.z > 90f ? rotationAngles.x < 90f : true;
    }

    private bool isWithinLowerBound()
    {
        //sould be rotationEulerAngles.z == 180f, but comparing floats is not a good idea
        //rotationEulerAngles.z can have values 180f and 0f, therefore conidtion > 90f was chosen
        var rotationAngles = cameraControllerTransform.localEulerAngles;
        return rotationAngles.z > 90f ? rotationAngles.x > 270f : true;
    }

    private void rotateCamera(Vector3 direction, float amount, Space relativeTo = Space.Self)
    {
        cameraControllerTransform.Rotate(direction * Time.deltaTime * rotatingSpeed * amount, relativeTo);
    }

    static class CameraRotateDirection
    {
        public static readonly Vector3 down = new Vector3(1, 0, 0);
        public static readonly Vector3 up = new Vector3(-1, 0, 0);
        public static readonly Vector3 right = new Vector3(0, -1, 0);
        public static readonly Vector3 left = new Vector3(0, 1, 0);
    }

    private void ZoomIn()
    {
        Zoom(direction: new Vector3(0, 0, -1));
    }

    private void ZoomOut()
    {
        Zoom(direction: new Vector3(0, 0, 1));
    }

    private void Zoom(Vector3 direction)
    {
        cameraTransform.localPosition += new Vector3(0, 0, -1) * zoomSpeed * Time.deltaTime * _zoom;

        var cameraPosition = cameraTransform.localPosition;
        if (cameraPosition.z < planetSurfaceHeight)
        {
            cameraPosition.z = planetSurfaceHeight;
            cameraTransform.localPosition = cameraPosition;
        }
            
    }
}