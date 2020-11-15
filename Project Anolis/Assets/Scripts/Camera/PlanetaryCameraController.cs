using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlanetaryCameraController
{
    private Transform _cameraTransform;
    private Transform _controllerTransform;
    private CameraManipulator _cameraManipulator;

    private float _rotatingSpeed;
    private float _minCameraHeight;
    private float _modeTransitionHeight;

    private float _verticalRotationAmount;
    private float _horizontalRotationAmount;
    private float _zoomSpeed;

    public PlanetaryCameraController(CameraManipulator cameraManipulator, Transform cameraTransform, Transform controllerTransform, float rotatingSpeed, float minCameraHeight, float modeTransitionHeight, float zoomSpeed)
    {
        _cameraManipulator = cameraManipulator;
        _cameraTransform = cameraTransform;
        _controllerTransform = controllerTransform;
        _rotatingSpeed = rotatingSpeed;
        _minCameraHeight = minCameraHeight;
        _modeTransitionHeight = modeTransitionHeight;
        _zoomSpeed = zoomSpeed;
        GameState.Get.ModeChanged += HandleModeChange;
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        var amount = context.ReadValue<Vector2>();
        _verticalRotationAmount = amount.y;
        _horizontalRotationAmount = amount.x;
    }

    public void OnZoom(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
        
        var amount = context.ReadValue<Vector2>().normalized.y;
        Zoom(amount);
    }

    private void Zoom(float amount)
    {
        _cameraManipulator.ChangeHeightBy(amount * _zoomSpeed);

        if (_cameraTransform.localPosition.z < _minCameraHeight)
            _cameraManipulator.SetHeightTo(_minCameraHeight);
        else if (_cameraTransform.localPosition.z > _modeTransitionHeight)
        {
            GameState.Get.ChangeModeToInterplanetary();
        }
    }

    private void HandleModeChange(GameState.Mode newMode)
    {
        if (newMode == GameState.Mode.Planetary)
            _cameraManipulator.CenterAtPlanet(GameState.Get.CurrentFocus);
    }

    public void MakeRotation()
    {
        if (_verticalRotationAmount != 0 && IsWithinBounds())
            _cameraManipulator.RotateVertivalyBy(_verticalRotationAmount * _rotatingSpeed);

        if (_horizontalRotationAmount != 0)
            _cameraManipulator.RotateHorizontalyBy(_horizontalRotationAmount * _rotatingSpeed);
    }

    private bool IsWithinBounds()
    {
        //when working with euler angles instead of quaternions we get some nasty conditions
        //this sould be cameraControllerTransform.localEulerAngles.z == 180f, but comparing floats is not a good idea
        //rotationEulerAngles.z can have values 180f and 0f, therefore condition > 90f was chosen
        if (_controllerTransform.localEulerAngles.z < 90f)
            return true;
        return _verticalRotationAmount > 0f ? IsWithinUpperBoundary() : IsWithinLowerBoundary();
    }

    private bool IsWithinUpperBoundary()
    {
        return _controllerTransform.localEulerAngles.x < 90f;
    }

    private bool IsWithinLowerBoundary()
    {
        return _controllerTransform.localEulerAngles.x > 270f;
    }
}