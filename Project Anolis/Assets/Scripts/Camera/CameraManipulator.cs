using UnityEngine;

public class CameraManipulator : MonoBehaviour
{
    [SerializeField] private float zoomSpeed = 25f;
    public float modeTransitionHeight = 50f;

    private Transform _cameraTransform;

    private void Awake()
    {
        _cameraTransform = GetComponentInChildren<Camera>().transform;
    }

    public void ChangeHeightBy(float amount)
    {
        _cameraTransform.localPosition += zoomSpeed * Time.deltaTime * amount * new Vector3(0, 0, -1);
    }

    public void Rotate(Vector3 direction, float amount, Space relativeTo = Space.Self)
    {
        transform.Rotate(Time.deltaTime * amount * direction, relativeTo);
    }

    public void SetHeightTo(float height)
    {
        var cameraPosition = _cameraTransform.localPosition;
        cameraPosition.z = height;
        _cameraTransform.localPosition = cameraPosition;
    }
}