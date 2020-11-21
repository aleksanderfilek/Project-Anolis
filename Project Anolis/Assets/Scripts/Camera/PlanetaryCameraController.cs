using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlanetaryCameraController
{
    private Transform _cameraTransform;
    private Transform _controllerTransform;
    private CameraManipulator _cameraManipulator;
    private ControllerManipulator _controllerManipulator;

    private float _verticalRotationAmount;
    private float _horizontalRotationAmount;

    public float RotatingSpeed { get; set; }
    public float MinCameraHeight { get; set; }
    public float ModeTransitionHeight { get; set; }
    public float ZoomSpeed { get; set; }

    public PlanetaryCameraController(CameraManipulator cameraManipulator, ControllerManipulator controllerManipulator,
        Transform cameraTransform, Transform controllerTransform)
    {
        _cameraManipulator = cameraManipulator;
        _controllerManipulator = controllerManipulator;
        _cameraTransform = cameraTransform;
        _controllerTransform = controllerTransform;
        GameState.Get.ModeChanged += HandleModeChange;
    }

    public void UpdateRotateAmounts(InputAction.CallbackContext context)
    {
        var amount = context.ReadValue<Vector2>();
        _verticalRotationAmount = amount.y;
        _horizontalRotationAmount = amount.x;
    }

    public void Zoom(InputAction.CallbackContext context)
    {
        var amount = context.ReadValue<Vector2>().normalized.y;
        _cameraManipulator.ChangeHeightBy(amount * ZoomSpeed);
        if (_cameraTransform.localPosition.z < MinCameraHeight)
            _cameraManipulator.SetHeightTo(MinCameraHeight);
        else if (_cameraTransform.localPosition.z > ModeTransitionHeight)
            GameState.Get.ChangeModeToInterplanetary();
    }

    private void HandleModeChange(GameState.Mode newMode)
    {
        if (newMode != GameState.Mode.Planetary)
            return;
        _controllerManipulator.CenterAtPlanet(GameState.Get.CurrentFocus);
        _cameraManipulator.SetHeightTo(15.0f); //todo change
    }

    public void MakeRotation()
    {
        if (_verticalRotationAmount != 0 && IsWithinBounds())
            _controllerManipulator.RotateVertivalyBy(_verticalRotationAmount * RotatingSpeed);

        if (_horizontalRotationAmount != 0)
            _controllerManipulator.RotateHorizontalyBy(_horizontalRotationAmount * RotatingSpeed);
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