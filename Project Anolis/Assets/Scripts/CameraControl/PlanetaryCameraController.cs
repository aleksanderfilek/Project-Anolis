using UnityEngine;
using UnityEngine.InputSystem;

namespace CameraControl
{
    public class PlanetaryCameraController
    {
        private CameraManipulator _cameraManipulator;
        private ControllerManipulator _controllerManipulator;

        public float RotationSpeed { get; set; }
        public float ZoomDistance { get; set; }

        private float _minCameraDistance;
        private float _modeTransitionDistance;
        private float _verticalRotationAmount;
        private float _horizontalRotationAmount;

        public PlanetaryCameraController(CameraManipulator cameraManipulator, ControllerManipulator controllerManipulator)
        {
            _cameraManipulator = cameraManipulator;
            _controllerManipulator = controllerManipulator;
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
            _cameraManipulator.ChangeHolderDisctanceBy(amount * ZoomDistance);
        
            if (_cameraManipulator.GetHolderDistance() < _minCameraDistance)
                _cameraManipulator.SetHolderDisctanceTo(_minCameraDistance);
            else if (_cameraManipulator.GetHolderDistance() > _modeTransitionDistance)
                GameState.Get.ChangeModeToInterplanetary();
        }

        public void HandleModeChangeToPlanetary(float modeTransitionDistance, float minCameraDistance)
        {
            _modeTransitionDistance = modeTransitionDistance;
            _minCameraDistance = minCameraDistance;
            _controllerManipulator.CenterAtPlanet(GameState.Get.CurrentFocus);
            var averageCameraDistance = (minCameraDistance + modeTransitionDistance) / 2;
            _cameraManipulator.SetHolderDisctanceTo(averageCameraDistance);
        }

        public void MakeRotation()
        {
            if (_verticalRotationAmount != 0 && IsWithinBounds())
                _controllerManipulator.RotateHolderVerticallyBy(_verticalRotationAmount * RotationSpeed);

            if (_horizontalRotationAmount != 0)
                _controllerManipulator.RotateHolderHorizontallyBy(_horizontalRotationAmount * RotationSpeed);
        }

        private bool IsWithinBounds()
        {
            //when working with euler angles instead of quaternions we get some nasty conditions
            //this should be cameraControllerTransform.localEulerAngles.z == 180f, but comparing floats is not a good idea
            //rotationEulerAngles.z can have values 180f and 0f, therefore condition > 90f was chosen
            if (_controllerManipulator.GetHolderRotation().z < 90f)
                return true;
            return _verticalRotationAmount > 0f ? IsWithinUpperBoundary() : IsWithinLowerBoundary();
        }

        private bool IsWithinUpperBoundary()
        {
            return _controllerManipulator.GetHolderRotation().x < 90f;
        }

        private bool IsWithinLowerBoundary()
        {
            return _controllerManipulator.GetHolderRotation().x > 270f;
        }
    }
}