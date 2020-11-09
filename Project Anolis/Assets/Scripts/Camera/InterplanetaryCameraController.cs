using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InterplanetaryCameraController : MonoBehaviour
{
    private float _horizontalMoveAmount;
    private float _verticalMoveAmount;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxCameraHeight;
    [SerializeField] private Vector3 rotation;
    [SerializeField] private Vector2 boundaries;
    
    private Transform _cameraTransform;
    private CameraManipulator _cameraManipulator;
    
    private void Awake()
    {
        _cameraManipulator = GetComponent<CameraManipulator>();
        _cameraTransform = GetComponentInChildren<Camera>().transform;
        PositionCamera();
    }

    public void PositionCamera()
    {
        transform.rotation = Quaternion.Euler(rotation);
    }

    private void Update()
    {
        MakeMovement();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        var amount = context.ReadValue<Vector2>();
        _horizontalMoveAmount = amount.x;
        _verticalMoveAmount = amount.y;
    }
    
    public void OnZoom(InputAction.CallbackContext context)
    {
        var amount = context.ReadValue<Vector2>().normalized.y;
        Zoom(amount);
    }
    
    private void Zoom(float amount)
    {
        _cameraManipulator.ChangeHeightBy(amount);

        if (_cameraTransform.localPosition.z > maxCameraHeight)
            _cameraManipulator.SetHeightTo(maxCameraHeight);
    }
    
    private void MakeMovement()
    {
        if (_horizontalMoveAmount != 0 && IsWithinHorizontalBoundary())
            transform.Translate(-_horizontalMoveAmount * moveSpeed, 0.0f, 0.0f, Space.World);

        if (_verticalMoveAmount != 0 && IsWithinVerticalBoundary())
            transform.Translate(0.0f, 0.0f, -_verticalMoveAmount * moveSpeed, Space.World);
    }

    private bool IsWithinHorizontalBoundary()
    {
        var position = transform.position;
        return _horizontalMoveAmount < 0 ? position.x < boundaries.x : position.x > -boundaries.x;
    }

    private bool IsWithinVerticalBoundary()
    {
        var position = transform.position;
        return _verticalMoveAmount < 0 ? position.z < boundaries.y : position.z > -boundaries.y;
    }
}
