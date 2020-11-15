using UnityEngine;
using UnityEngine.InputSystem;

//todo remove merge on zoom with zoom

public class InterplanetaryCameraController
{
    private float _horizontalMoveAmount;
    private float _verticalMoveAmount;
    
    private Transform _cameraTransform;
    private Transform _controllerTransform;
    private CameraManipulator _cameraManipulator;
    
    private Vector3 _fixedRotation;
    private Vector2 _boundaries;
    private float _maxCameraHeight;
    private float _moveSpeed;
    private float _zoomSpeed;

    public InterplanetaryCameraController(CameraManipulator cameraManipulator, Transform controllerTransform, Transform cameraTransform, 
        Vector3 fixedRotation, float maxCameraHeight, float moveSpeed, float zoomSpeed, Vector2 boundaries)
    {
        _cameraManipulator = cameraManipulator;
        _controllerTransform = controllerTransform;
        _cameraTransform = cameraTransform;
        _fixedRotation = fixedRotation;
        _maxCameraHeight = maxCameraHeight;
        _moveSpeed = moveSpeed;
        _zoomSpeed = zoomSpeed;
        _boundaries = boundaries;
        GameState.Get.ModeChanged += HandleModeChange;
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
        _cameraManipulator.ChangeHeightBy(amount * _zoomSpeed);

        if (_cameraTransform.localPosition.z > _maxCameraHeight)
            _cameraManipulator.SetHeightTo(_maxCameraHeight);
    }
    
    private void HandleModeChange(GameState.Mode newMode)
    {
        if (newMode == GameState.Mode.Interplanetary) 
            _cameraManipulator.SetRotationTo(_fixedRotation);
    }
    
    public void MakeMovement()
    {
        if (_horizontalMoveAmount != 0 && IsWithinHorizontalBoundary())
            _cameraManipulator.TranslateHorizontalyBy(_horizontalMoveAmount * _moveSpeed);

        if (_verticalMoveAmount != 0 && IsWithinVerticalBoundary())
            _cameraManipulator.TranslateVerticalyBy(_verticalMoveAmount * _moveSpeed);
    }

    private bool IsWithinHorizontalBoundary()
    {
        var position = _controllerTransform.position;
        return _horizontalMoveAmount < 0 ? position.x < _boundaries.x : position.x > -_boundaries.x;
    }

    private bool IsWithinVerticalBoundary()
    {
        var position = _controllerTransform.position;
        return _verticalMoveAmount < 0 ? position.z < _boundaries.y : position.z > -_boundaries.y;
    }
}
