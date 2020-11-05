using UnityEngine;

public class Tile
{
    public Vector3 Position { get; }
    public GameObject TileContent { get; set; }

    public Tile(Vector3 position)
    {
        Position = position;
    }
}