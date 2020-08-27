using UnityEngine;

[CreateAssetMenu(fileName = "New Tile Object", menuName = "Scriptable Objects/Tile Object")]
public class TileScriptableObject : ScriptableObject
{
    public string objectName;
    public ObjectType objectType;
    public GameObject prefab;
}
