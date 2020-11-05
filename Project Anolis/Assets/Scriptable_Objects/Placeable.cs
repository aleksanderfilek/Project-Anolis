using UnityEngine;

[CreateAssetMenu(fileName = "New Placeable", menuName = "Scriptable Objects")]
public class Placeable : ScriptableObject
{
    [SerializeField] public string objectName;
    public GameObject prefab;
    [TextAreaAttribute(15,20)] public string description;
}
