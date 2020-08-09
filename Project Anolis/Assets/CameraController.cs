using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Animations;
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
        UpdateInput();
        MakeMovement();
    }

    private void UpdateInput()
    {
        _rotationVertical = Input.GetAxis("Vertical");
        _rotationHorizontal = Input.GetAxis("Horizontal");
        _zoom = Input.GetAxis("Mouse ScrollWheel");
    }

    private void MakeMovement()
    {
        if (_rotationVertical != 0 && IsWithinBounds())
            rotateCamera(direction: new Vector3(-1, 0, 0), amount: _rotationVertical);

        if (_rotationHorizontal != 0)
            rotateCamera(direction: new Vector3(0, -1, 0), amount: _rotationHorizontal, relativeTo: Space.World);

        if (_zoom != 0f)
            Zoom();
    }

    private bool IsWithinBounds()
    {
        var rotationAngles = cameraControllerTransform.localEulerAngles;
        
        //sould be rotationEulerAngles.z == 180f, but comparing floats is not a good idea
        //rotationEulerAngles.z can have values 180f and 0f, therefore conidtion > 90f was chosen
        if (rotationAngles.z < 90f)
            return true;

        return _rotationVertical > 0f ? IsWithinUpperBoundary() : IsWithinLowerBoundary();
    }

    private bool IsWithinUpperBoundary()
    {
        return cameraControllerTransform.localEulerAngles.x < 90f;
    }

    private bool IsWithinLowerBoundary()
    {
        return cameraControllerTransform.localEulerAngles.x > 270f;
    }

    private void rotateCamera(Vector3 direction, float amount, Space relativeTo = Space.Self)
    {
        cameraControllerTransform.Rotate(direction * Time.deltaTime * rotatingSpeed * amount, relativeTo);
    }

    private void Zoom()
    {
        cameraTransform.localPosition += new Vector3(0, 0, -1) * zoomSpeed * Time.deltaTime * _zoom;
        if (cameraTransform.localPosition.z < planetSurfaceHeight)
            FixCameraHeight();
    }

    private void FixCameraHeight()
    {
        var cameraPosition = cameraTransform.localPosition;
        cameraPosition.z = planetSurfaceHeight;
        cameraTransform.localPosition = cameraPosition;
    }
}