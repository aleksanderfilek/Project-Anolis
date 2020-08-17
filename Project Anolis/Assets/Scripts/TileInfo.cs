using UnityEngine;

public enum TerrrainType
{
    Barren,
    Grass,
    Snow,
    Mountain,
    Forest,
    Water,
    Lava,
}

public enum ObjectType
{
    None,
    Tree,
    Rock,
    MaterialDeposit,
}

public struct Tile
{
    public TerrrainType terrainType;
    public ObjectType objectType;

    public Vector3 normal;
}