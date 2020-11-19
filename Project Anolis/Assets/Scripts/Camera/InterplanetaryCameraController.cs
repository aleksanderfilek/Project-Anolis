using UnityEngine;
using UnityEngine.InputSystem;

public class InterplanetaryCameraController
{
    private float _horizontalMoveAmount;
    private float _verticalMoveAmount;

    private Transform _cameraTransform;
    private Transform _controllerTransform;
    private CameraManipulator _cameraManipulator;
    private ControllerManipulator _controllerManipulator;

    public Vector3 FixedRotation { get; set; }
    public Vector2 Boundaries { get; set; }
    public float MaxCameraHeight { get; set; }
    public float MoveSpeed { get; set; }
    public float ZoomSpeed { get; set; }

    public InterplanetaryCameraController(CameraManipulator cameraManipulator,
        ControllerManipulator controllerManipulator, Transform controllerTransform, Transform cameraTransform)
    {
        _cameraManipulator = cameraManipulator;
        _controllerManipulator = controllerManipulator;
        _controllerTransform = controllerTransform;
        _cameraTransform = cameraTransform;
        GameState.Get.ModeChanged += HandleModeChange;
    }

    public void UpdateMoveAmounts(InputAction.CallbackContext context)
    {
        var amount = context.ReadValue<Vector2>();
        _horizontalMoveAmount = amount.x;
        _verticalMoveAmount = amount.y;
    }

    public void Zoom(InputAction.CallbackContext context)
    {
        var amount = context.ReadValue<Vector2>().normalized.y;
        _cameraManipulator.ChangeHeightBy(amount * ZoomSpeed);
        if (_cameraTransform.localPosition.z > MaxCameraHeight)
            _cameraManipulator.SetHeightTo(MaxCameraHeight);
    }

    private void HandleModeChange(GameState.Mode newMode)
    {
        if (newMode == GameState.Mode.Interplanetary)
            _controllerManipulator.SetRotationTo(FixedRotation);
    }

    public void MakeMovement()
    {
        if (_horizontalMoveAmount != 0 && IsWithinHorizontalBoundary())
            _controllerManipulator.TranslateHorizontalyBy(_horizontalMoveAmount * MoveSpeed);

        if (_verticalMoveAmount != 0 && IsWithinVerticalBoundary())
            _controllerManipulator.TranslateVerticalyBy(_verticalMoveAmount * MoveSpeed);
    }

    private bool IsWithinHorizontalBoundary()
    {
        var position = _controllerTransform.position;
        return _horizontalMoveAmount < 0 ? position.x < Boundaries.x : position.x > -Boundaries.x;
    }

    private bool IsWithinVerticalBoundary()
    {
        var position = _controllerTransform.position;
        return _verticalMoveAmount < 0 ? position.z < Boundaries.y : position.z > -Boundaries.y;
    }
}