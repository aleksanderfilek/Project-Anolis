using UnityEngine;

[CreateAssetMenu(fileName = "New Tile Object", menuName = "Custom/Tile Object")]
public class Placeable : ScriptableObject
{
    public string objectName;
    public ObjectType objectType;
    public GameObject prefab;
}
