using UnityEngine;
using UnityEngine.InputSystem;

public class InterplanetaryCameraController
{
    private float _horizontalMoveAmount;
    private float _verticalMoveAmount;

    private CameraManipulator _cameraManipulator;
    private ControllerManipulator _controllerManipulator;

    public Vector3 CameraRotation { get; set; }
    public Vector2 MovementBoundaries { get; set; }
    public float MaxCameraDistance { get; set; }
    public float MovementSpeed { get; set; }
    public float ZoomSpeed { get; set; }

    public InterplanetaryCameraController(CameraManipulator cameraManipulator,
        ControllerManipulator controllerManipulator)
    {
        _cameraManipulator = cameraManipulator;
        _controllerManipulator = controllerManipulator;
        GameState.Get.ModeChanged += HandleModeChangeToInterplanetary;
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
        _cameraManipulator.ChangeHolderDisctanceBy(amount * ZoomSpeed);
        if (_cameraManipulator.GetHolderDistance() > MaxCameraDistance)
            _cameraManipulator.SetHolderDisctanceTo(MaxCameraDistance);
    }

    private void HandleModeChangeToInterplanetary(GameState.Mode newMode)
    {
        if (newMode != GameState.Mode.Interplanetary) 
            return;
        _controllerManipulator.SetRotationTo(CameraRotation);
    }

    public void MakeMovement()
    {
        if (_horizontalMoveAmount != 0 && IsWithinHorizontalBoundary())
            _controllerManipulator.TranslateHorizontallyBy(_horizontalMoveAmount * MovementSpeed);

        if (_verticalMoveAmount != 0 && IsWithinVerticalBoundary())
            _controllerManipulator.TranslateVerticallyBy(_verticalMoveAmount * MovementSpeed);
    }

    private bool IsWithinHorizontalBoundary()
    {
        var position = _controllerManipulator.GetHolderPosition();
        return _horizontalMoveAmount < 0 ? position.x < MovementBoundaries.x : position.x > -MovementBoundaries.x;
    }

    private bool IsWithinVerticalBoundary()
    {
        var position = _controllerManipulator.GetHolderPosition();
        return _verticalMoveAmount < 0 ? position.z < MovementBoundaries.y : position.z > -MovementBoundaries.y;
    }
}