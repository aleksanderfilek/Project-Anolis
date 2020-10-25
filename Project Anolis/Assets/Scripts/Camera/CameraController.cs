using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.XR.WSA.Input;

[RequireComponent(typeof(PlanetaryCameraController))]
[RequireComponent(typeof(InterplanetaryCameraController))]
public class CameraController : MonoBehaviour
{
    [SerializeField] private float zoomSpeed = 25f;
    [SerializeField] private float minCameraHeight = 10f;
    [SerializeField] private GameState state;

    private Transform _cameraTransform;

    private PlanetaryCameraController _planetaryCameraController;

    private float _zoomAmount;
    
    private void Awake()
    {
        _cameraTransform = transform.GetChild(0);
        _planetaryCameraController = GetComponent<PlanetaryCameraController>();
    }

    private void Update()
    {
        _planetaryCameraController.MakeMovement();
    }

    public void OnZoom(InputAction.CallbackContext context)
    {
        var amount = context.ReadValue<Vector2>().normalized.y;
        Zoom(amount);
    }
    
    private void Zoom(float amount)
    {
        _cameraTransform.localPosition += zoomSpeed * Time.deltaTime * amount * new Vector3(0, 0, -1);
        if (_cameraTransform.localPosition.z < minCameraHeight)
            FixCameraHeight();
    }

    private void FixCameraHeight()
    {
        var cameraPosition = _cameraTransform.localPosition;
        cameraPosition.z = minCameraHeight;
        _cameraTransform.localPosition = cameraPosition;
    }
}