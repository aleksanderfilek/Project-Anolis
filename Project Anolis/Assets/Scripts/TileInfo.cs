using UnityEngine;

// WARNING: put habitable and inhabitable terrain types as well as buildings and non-buildings together

public enum TerrrainType
{
    // habitable
    Barren,
    Grass,
    Snow,
    Mountain,
    Forest,

    // this flag separates habitable and inhabitable terrain types
    HabitableFlag,

    // inhabitable
    Water,
    Lava,
}



public enum ObjectType
{
    // non-buildings
    None,
    Tree,
    Rock,
    MaterialDeposit,

    // this flag separates building from other objects
    BuildableFlag,

    // buildings
    BuildingA,
    BuildingB,
}

public struct Tile
{
    public TerrrainType terrainType;

    public Vector3 normal;
    public Vector3 position;

    public ObjectType objectType;
    public GameObject objectPlaced;
}