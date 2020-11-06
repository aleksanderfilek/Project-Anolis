using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

[RequireComponent(typeof(CameraManipulator))]
public class PlanetaryCameraController : MonoBehaviour
{
    [SerializeField] private float rotatingSpeed = 100f;
    [SerializeField] private float minCameraHeight;

    private Transform _cameraTransform;
    private CameraManipulator _cameraManipulator;

    private float _verticalRotationAmount;
    private float _horizontalRotationAmount;

    private void Awake()
    {
        _cameraManipulator = GetComponent<CameraManipulator>();
        _cameraTransform = transform.GetChild(0);
    }

    private void Update()
    {
        MakeRotation();
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        var amount = context.ReadValue<Vector2>();
        _verticalRotationAmount = amount.y;
        _horizontalRotationAmount = amount.x;
    }

    public void OnZoom(InputAction.CallbackContext context)
    {
        var amount = context.ReadValue<Vector2>().normalized.y;
        Zoom(amount);
    }

    private void Zoom(float amount)
    {
        _cameraManipulator.ChangeHeightBy(amount);

        if (_cameraTransform.localPosition.z < minCameraHeight)
            _cameraManipulator.SetHeightTo(minCameraHeight);
        else if (_cameraTransform.localPosition.z > _cameraManipulator.modeTransitionHeight)
        {
            GameState.Get.CurrentMode = GameState.Mode.Interplanetary;
        }
    }

    private void MakeRotation()
    {
        if (_verticalRotationAmount != 0 && IsWithinBounds())
            _cameraManipulator.Rotate(new Vector3(-1, 0, 0), _verticalRotationAmount * rotatingSpeed);

        if (_horizontalRotationAmount != 0)
            _cameraManipulator.Rotate(new Vector3(0, -1, 0), _horizontalRotationAmount * rotatingSpeed,
                Space.World);
    }

    private bool IsWithinBounds()
    {
        //when working with euler angles instead of quaternions we get some nasty conditions
        //this sould be cameraControllerTransform.localEulerAngles.z == 180f, but comparing floats is not a good idea
        //rotationEulerAngles.z can have values 180f and 0f, therefore condition > 90f was chosen
        if (transform.localEulerAngles.z < 90f)
            return true;
        return _verticalRotationAmount > 0f ? IsWithinUpperBoundary() : IsWithinLowerBoundary();
    }

    private bool IsWithinUpperBoundary()
    {
        return transform.localEulerAngles.x < 90f;
    }

    private bool IsWithinLowerBoundary()
    {
        return transform.localEulerAngles.x > 270f;
    }
}