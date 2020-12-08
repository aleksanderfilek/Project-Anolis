using UnityEngine;

public class ControllerManipulator
{
    private Transform _controllerTransform;

    public ControllerManipulator(Transform controllerTransform)
    {
        _controllerTransform = controllerTransform;
    }

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
    
    public void CenterAtPlanet(GameObject planet)
    {
        _controllerTransform.position = planet.transform.position;
    }

    public void SetRotationTo(Vector3 rotation)
    {
        _controllerTransform.rotation = Quaternion.Euler(rotation);
    }
}