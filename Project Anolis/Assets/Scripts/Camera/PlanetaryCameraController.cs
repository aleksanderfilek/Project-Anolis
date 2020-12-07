using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlanetaryCameraController
{
    private Transform _cameraTransform;
    private Transform _controllerTransform;
    private CameraManipulator _cameraManipulator;
    private ControllerManipulator _controllerManipulator;

    public float RotationSpeed { get; set; }
    public float MinCameraDistanceFactor { get; set; }
    public float ModeTransitionDistanceFactor { get; set; }
    public float ZoomSpeed { get; set; }

    private float _minCameraDistance;
    private float _modeTransitionDistance;
    private float _verticalRotationAmount;
    private float _horizontalRotationAmount;

    public PlanetaryCameraController(CameraManipulator cameraManipulator, ControllerManipulator controllerManipulator,
        Transform cameraTransform, Transform controllerTransform)
    {
        _cameraManipulator = cameraManipulator;
        _controllerManipulator = controllerManipulator;
        _cameraTransform = cameraTransform;
        _controllerTransform = controllerTransform;
        GameState.Get.ModeChanged += HandleModeChangeToPlanetary;
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
        if (_cameraTransform.localPosition.z < _minCameraDistance)
            _cameraManipulator.SetHeightTo(_minCameraDistance);
        else if (_cameraTransform.localPosition.z > _modeTransitionDistance)
            GameState.Get.ChangeModeToInterplanetary();
    }

    private void HandleModeChangeToPlanetary(GameState.Mode newMode)
    {
        if (newMode != GameState.Mode.Planetary)
            return;
        _controllerManipulator.CenterAtPlanet(GameState.Get.CurrentFocus);
        var radius = GameState.Get.CurrentFocus.GetComponent<Planet>().Radius;
        _modeTransitionDistance = radius * ModeTransitionDistanceFactor;
        _minCameraDistance = radius * MinCameraDistanceFactor;
        _cameraManipulator.SetHeightTo(_minCameraDistance); //todo change
    }

    public void MakeRotation()
    {
        if (_verticalRotationAmount != 0 && IsWithinBounds())
            _controllerManipulator.RotateVerticallyBy(_verticalRotationAmount * RotationSpeed);

        if (_horizontalRotationAmount != 0)
            _controllerManipulator.RotateHorizontallyBy(_horizontalRotationAmount * RotationSpeed);
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