using UnityEngine;

namespace CameraControl
{
    public class ControllerManipulator
    {
        private Transform _controllerTransform;
        private Transform _holderTransform;

        public ControllerManipulator(Transform controllerTransform, Transform holderTransform)
        {
            _controllerTransform = controllerTransform;
            _holderTransform = holderTransform;
        }

        public void MoveControllerTowardsHolder(float movementSpeed)
        {
            _controllerTransform.position = Vector3.Lerp(_controllerTransform.position, _holderTransform.position, movementSpeed * Time.deltaTime);
        }

        public void RotateControllerTowardsHolder(float rotationSmoothSpeed)
        {
            _controllerTransform.rotation = Quaternion.Lerp(_controllerTransform.rotation, _holderTransform.rotation, rotationSmoothSpeed * Time.deltaTime);
        }
    
        public void RotateHolderVerticallyBy(float amount)
        {
            _holderTransform.Rotate(Time.deltaTime * amount * new Vector3(-1, 0, 0));
        }

        public void RotateHolderHorizontallyBy(float amount)
        {
            _holderTransform.Rotate(Time.deltaTime * amount * new Vector3(0, -1, 0), Space.World);
        }

        public void SetHolderRotationTo(Vector3 rotation)
        {
            _holderTransform.rotation = Quaternion.Euler(rotation);
        }
    
        public void TranslateVerticallyBy(float amount)
        {
            _holderTransform.Translate(0.0f, 0.0f, -amount * Time.deltaTime, Space.World);
        }

        public void TranslateHorizontallyBy(float amount)
        {
            _holderTransform.Translate(-amount * Time.deltaTime, 0.0f, 0.0f, Space.World);
        }

        public void CenterAtPlanet(GameObject planet)
        {
            _holderTransform.position = planet.transform.position;
        }

        public Vector3 GetHolderPosition()
        {
            return _holderTransform.position;
        }

        public Vector3 GetHolderRotation()
        {
            return _holderTransform.localEulerAngles;
        }
    }
}