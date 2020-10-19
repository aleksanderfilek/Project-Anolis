using UnityEngine;

[CreateAssetMenu(fileName = "New Placeable", menuName = "Scriptable Objects")]
public class Placeable : ScriptableObject
{
    public string objectName;
    public ObjectType objectType;
    public GameObject prefab;
    [TextAreaAttribute(15,20)] public string description;
}
