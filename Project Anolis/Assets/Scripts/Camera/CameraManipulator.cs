using UnityEngine;

public class CameraManipulator
{
    private Transform _cameraTransform;

    public CameraManipulator(Transform cameraTransfrom)
    {
        _cameraTransform = cameraTransfrom;
    }
    
    public void ChangeHeightBy(float amount)
    {
        _cameraTransform.localPosition += Time.deltaTime * amount * new Vector3(0, 0, -1);
    }

    public void SetHeightTo(float height)
    {
        var cameraPosition = _cameraTransform.localPosition;
        cameraPosition.z = height;
        _cameraTransform.localPosition = cameraPosition;
    }
}