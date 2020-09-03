using UnityEngine;

public enum TerrainType
{
    Habitable,
    Inhabitable,
    Liquid,
}

public enum ObjectType
{
    None,
    Natural,
    Ore,
    Building,
}

public struct Tile
{
    public TerrainType terrainType;

    public Vector3 normal;
    public Vector3 position;

    public string objectName;
    public ObjectType objectType;
    public GameObject objectPlaced;

    public int neighbor1;
    public int neighbor2;
    public int neighbor3;
}