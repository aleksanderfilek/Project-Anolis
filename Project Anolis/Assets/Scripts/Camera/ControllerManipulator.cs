using UnityEngine;

public class ControllerManipulator
{
    private Transform _controllerTransform;

    public ControllerManipulator(Transform controllerTransform)
    {
        _controllerTransform = controllerTransform;
    }

    public void RotateVerticallyBy(float amount)
    {
        _controllerTransform.Rotate(Time.deltaTime * amount * new Vector3(-1, 0, 0));
    }

    public void RotateHorizontallyBy(float amount)
    {
        _controllerTransform.Rotate(Time.deltaTime * amount * new Vector3(0, -1, 0), Space.World);
    }

    public void TranslateVerticallyBy(float amount)
    {
        _controllerTransform.Translate(0.0f, 0.0f, -amount * Time.deltaTime, Space.World);
    }

    public void TranslateHorizontallyBy(float amount)
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