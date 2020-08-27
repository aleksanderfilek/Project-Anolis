using UnityEngine;

// WARNING: put habitable and inhabitable terrain types as well as buildings and non-buildings together

public enum TerrrainType
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
    public TerrrainType terrainType;

    public Vector3 normal;
    public Vector3 position;

    public ObjectType objectType;
    public GameObject objectPlaced;
}