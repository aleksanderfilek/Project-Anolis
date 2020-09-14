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

public class Tile
{
    public Vector3 Position { get; }
    public GameObject TileContent { get; set; }

    public Tile(Vector3 position)
    {
        Position = position;
    }
}