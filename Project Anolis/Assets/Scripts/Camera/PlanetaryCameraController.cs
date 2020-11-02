using UnityEngine;
using UnityEngine.InputSystem;

public class PlanetaryCameraController : MonoBehaviour
{
    [SerializeField] private float rotatingSpeed = 100f;

    private Transform _cameraTransform;
    
    private float _verticalRotationAmount;
    private float _horizontalRotationAmount;

    private void Awake()
    {
        _cameraTransform = transform.GetChild(0);
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        var amount = context.ReadValue<Vector2>();
        _verticalRotationAmount = amount.y;
        _horizontalRotationAmount = amount.x;
    }

    public void MakeMovement()
    {
        if (_verticalRotationAmount != 0 && IsWithinBounds())
            RotateCamera(direction: new Vector3(-1, 0, 0), amount: _verticalRotationAmount);
        
        if (_horizontalRotationAmount != 0)
            RotateCamera(direction: new Vector3(0, -1, 0), amount: _horizontalRotationAmount, relativeTo: Space.World);
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

    private void RotateCamera(Vector3 direction, float amount, Space relativeTo = Space.Self)
    {
        transform.Rotate(Time.deltaTime * rotatingSpeed * amount * direction, relativeTo);
    }
}