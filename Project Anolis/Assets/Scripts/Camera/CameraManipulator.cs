using UnityEngine;

public class CameraManipulator
{
    private Transform _cameraTransform;
    private Transform _holderTransform;

    public CameraManipulator(Transform cameraTransform, Transform holderTransform)
    {
        _cameraTransform = cameraTransform;
        _holderTransform = holderTransform;
    }

    public void MoveCameraTowardsHolder(float zoomSpeed)
    {
        _cameraTransform.localPosition = Vector3.Lerp(_cameraTransform.localPosition, _holderTransform.localPosition, zoomSpeed * Time.deltaTime);
    }

    public void ChangeHolderDisctanceBy(float amount)
    {
        _holderTransform.localPosition += Time.deltaTime * amount * new Vector3(0, 0, -1);
    }

    public void SetHolderDisctanceTo(float height)
    {
        var holderPosition = _holderTransform.localPosition;
        holderPosition.z = height;
        _holderTransform.localPosition = holderPosition;
    }

    public float GetHolderDistance()
    {
        return _holderTransform.localPosition.z;
    }
}