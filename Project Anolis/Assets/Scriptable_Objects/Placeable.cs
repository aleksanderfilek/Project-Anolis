using UnityEngine;

[CreateAssetMenu(fileName = "New Tile Object", menuName = "Scriptable Objects/Tile Object")]
public class Placeable : ScriptableObject
{
    public string objectName;
    public ObjectType objectType;
    public GameObject prefab;
}
