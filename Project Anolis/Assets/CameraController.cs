using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SocialPlatforms;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _cameraControllerTransform;
    [SerializeField] private Transform _cameraTransform;

    [SerializeField] private float _rotatingSpeed = 100f;
    [SerializeField] private float _zoomSpeed = 25f;

    [SerializeField] private float _planetSurfaceHeight = 1f; 

    private float _verticalRotationAmount = 0f;
    private float _horizontalRotationAmount = 0f;
    private float _zoomAmount = 0f;

    void Update()
    {
        UpdateInput();
        MakeMovement();
    }

    private void UpdateInput()
    {
        _verticalRotationAmount = Input.GetAxis("Vertical");
        _horizontalRotationAmount = Input.GetAxis("Horizontal");
        _zoomAmount = Input.GetAxis("Mouse ScrollWheel");
    }

    private void MakeMovement()
    {
        if (_verticalRotationAmount != 0 && IsWithinBounds())
            RotateCamera(direction: new Vector3(-1, 0, 0), amount: _verticalRotationAmount);

        if (_horizontalRotationAmount != 0)
            RotateCamera(direction: new Vector3(0, -1, 0), amount: _horizontalRotationAmount, relativeTo: Space.World);

        if (_zoomAmount != 0f)
            Zoom(direction: new Vector3(0, 0, -1));
    }

    private bool IsWithinBounds()
    {
        //when working with euler angles instead of quaternions we get some nasty conditions
        //this sould be cameraControllerTransform.localEulerAngles.z == 180f, but comparing floats is not a good idea
        //rotationEulerAngles.z can have values 180f and 0f, therefore condition > 90f was chosen
        if (_cameraControllerTransform.localEulerAngles.z < 90f)
            return true;
        return _verticalRotationAmount > 0f ? IsWithinUpperBoundary() : IsWithinLowerBoundary();
    }

    private bool IsWithinUpperBoundary()
    {
        return _cameraControllerTransform.localEulerAngles.x < 90f;
    }

    private bool IsWithinLowerBoundary()
    {
        return _cameraControllerTransform.localEulerAngles.x > 270f;
    }

    private void RotateCamera(Vector3 direction, float amount, Space relativeTo = Space.Self)
    {
        _cameraControllerTransform.Rotate(direction * Time.deltaTime * _rotatingSpeed * amount, relativeTo);
    }

    private void Zoom(Vector3 direction)
    {
        _cameraTransform.localPosition += direction * _zoomSpeed * Time.deltaTime * _zoomAmount;
        if (_cameraTransform.localPosition.z < _planetSurfaceHeight)
            FixCameraHeight();
    }

    private void FixCameraHeight()
    {
        var cameraPosition = _cameraTransform.localPosition;
        cameraPosition.z = _planetSurfaceHeight;
        _cameraTransform.localPosition = cameraPosition;
    }
}