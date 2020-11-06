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
    
    private Transform _cameraTransform;
    private CameraManipulator _cameraManipulator;
    
    private void Awake()
    {
        _cameraManipulator = GetComponent<CameraManipulator>(); 
        _cameraTransform = GetComponentInChildren<Camera>().transform;
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
        else if (_cameraTransform.localPosition.z < _cameraManipulator.modeTransitionHeight)
        {
            GameState.Get.CurrentMode = GameState.Mode.Planetary;
        }
    }
    
    private void MakeMovement()
    {
        if (_horizontalMoveAmount != 0 && IsWithinBounds())
            transform.Translate(_horizontalMoveAmount * moveSpeed, 0.0f, 0.0f);

        if (_verticalMoveAmount != 0 && IsWithinBounds())
            transform.Translate(0.0f, 0.0f, _verticalMoveAmount * moveSpeed, Space.World);
    }

    private bool IsWithinBounds()
    {
        return true;
    }
}
