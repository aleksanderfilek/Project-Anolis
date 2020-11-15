using System.Runtime.InteropServices;
using UnityEngine;

//todo split into CameraManiupulator and ControllerManipulator

public class CameraManipulator
{
    private Transform _controllerTransform;
    private Transform _cameraTransform;

    public CameraManipulator(Transform controllerTransform, Transform cameraTransfrom)
    {
        _controllerTransform = controllerTransform;
        _cameraTransform = cameraTransfrom;
    }
    
    public void ChangeHeightBy(float amount)
    {
        _cameraTransform.localPosition += Time.deltaTime * amount * new Vector3(0, 0, -1);
    }

    // public void RotateBy(float amount, Vector3 direction, Space relativeTo = Space.Self)
    // {
    //     _controllerTransform.Rotate(Time.deltaTime * amount * direction, relativeTo);
    // }
    
    public void RotateVertivalyBy(float amount)
    {
        _controllerTransform.Rotate(Time.deltaTime * amount * new Vector3(-1, 0, 0));
    }
    
    public void RotateHorizontalyBy(float amount)
    {
        _controllerTransform.Rotate(Time.deltaTime * amount * new Vector3(0, -1, 0), Space.World);
    }

    
    public void TranslateVerticalyBy(float amount)
    {
        _controllerTransform.Translate(0.0f, 0.0f, -amount * Time.deltaTime, Space.World);
    }

    public void TranslateHorizontalyBy(float amount)
    {
        _controllerTransform.Translate(-amount * Time.deltaTime, 0.0f, 0.0f, Space.World); 
    }

    public void SetHeightTo(float height)
    {
        var cameraPosition = _cameraTransform.localPosition;
        cameraPosition.z = height;
        _cameraTransform.localPosition = cameraPosition;
    }

    public void CenterAtPlanet(GameObject planet)
    {
        _controllerTransform.position = planet.transform.position;
        SetHeightTo(15.0f);    //todo change
    }

    public void SetRotationTo(Vector3 rotation)
    {
        _controllerTransform.rotation = Quaternion.Euler(rotation);
    }
}