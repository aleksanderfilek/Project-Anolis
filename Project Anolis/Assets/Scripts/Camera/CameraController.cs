using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [Header("Planetary Mode")]
    [SerializeField] private float rotatingSpeed = 100f;
    [SerializeField] private float zoomSpeed = 25f;
    [SerializeField] private float planetSurfaceHeight = 1f;

    [Header("References to other objects")] 
    [SerializeField] private GameState state;
    
    
    private Transform _cameraTransform;
    private Keyboard _keyboard;
    private Mouse _mouse;
    
    private float _verticalRotationAmount;
    private float _horizontalRotationAmount;
    private float _zoomAmount;

    private void Awake()
    {
        _cameraTransform = transform.GetChild(0);
        _keyboard = Keyboard.current;
        _mouse = Mouse.current;
    }

    private void Update()
    {
        UpdateInput();
        MakeMovement();
    }

    public void TestButton()
    {
        Debug.Log("Przycisk został naciśnięty?");
    }
    
    private void UpdateInput()
    {
        if(_keyboard.wKey.isPressed)
            _verticalRotationAmount = 1.0f;
        
        if(_keyboard.sKey.isPressed)
            _verticalRotationAmount = -1.0f;
        
        if(_keyboard.dKey.isPressed)
            _horizontalRotationAmount = 1.0f;
        
        if(_keyboard.aKey.isPressed)
            _horizontalRotationAmount = -1.0f;
    }

    private void MakeMovement()
    {
        if (_verticalRotationAmount != 0 && IsWithinBounds())
            RotateCamera(direction: new Vector3(-1, 0, 0), amount: _verticalRotationAmount);

        if (_horizontalRotationAmount != 0)
            RotateCamera(direction: new Vector3(0, -1, 0), amount: _horizontalRotationAmount, relativeTo: Space.World);

        if (_zoomAmount != 0f)
            Zoom(direction: new Vector3(0, 0, -1));

        _horizontalRotationAmount = 0f;
        _verticalRotationAmount = 0f;
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

    private void Zoom(Vector3 direction)
    {
        _cameraTransform.localPosition += zoomSpeed * Time.deltaTime * _zoomAmount * direction;
        if (_cameraTransform.localPosition.z < planetSurfaceHeight)
            FixCameraHeight();
    }

    private void FixCameraHeight()
    {
        var cameraPosition = _cameraTransform.localPosition;
        cameraPosition.z = planetSurfaceHeight;
        _cameraTransform.localPosition = cameraPosition;
    }
}
