using UnityEngine;
using UnityEngine.InputSystem;

namespace CameraControl
{
    public class InterplanetaryCameraController
    {
        private float _horizontalMoveAmount;
        private float _verticalMoveAmount;

        private CameraManipulator _cameraManipulator;
        private ControllerManipulator _controllerManipulator;

        public Vector2 MovementBoundaries { get; set; }
        public float MaxCameraDistance { get; set; }
        public float MovementSpeed { get; set; }
        public float ZoomSpeed { get; set; }
        public float MinCameraDistance { get; set; }

        public InterplanetaryCameraController(CameraManipulator cameraManipulator,
            ControllerManipulator controllerManipulator)
        {
            _cameraManipulator = cameraManipulator;
            _controllerManipulator = controllerManipulator;
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
        
            if (_cameraManipulator.GetHolderDistance() < MinCameraDistance)
                _cameraManipulator.SetHolderDisctanceTo(MinCameraDistance);
            else if (_cameraManipulator.GetHolderDistance() > MaxCameraDistance)
                _cameraManipulator.SetHolderDisctanceTo(MaxCameraDistance);
        }

        public void HandleModeChangeToInterplanetary(Vector3 cameraRotation)
        {
            _cameraManipulator.SetHolderDisctanceTo(MinCameraDistance);
            _controllerManipulator.SetHolderRotationTo(cameraRotation);
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
}