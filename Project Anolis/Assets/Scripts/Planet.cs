using UnityEngine;
using System.Collections.Generic;

public enum TerrainType
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
    public TerrainType terrainType;
    public ObjectType objectType;

    public Vector3 normal;
}

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class Planet : MonoBehaviour
{
    [SerializeField] private float _radius = 1f;
    [SerializeField] private int _iterations = 1;
    [SerializeField] private float _intensivity = 0.1f;
    [SerializeField] private int _seed = -1;

    public Tile[] Tiles { get; private set; }

    public void Start()
    {
        var meshFilter = GetComponent<MeshFilter>();
        var planetMesh = PlanetGenerator.Generate(_radius, _iterations, _intensivity, ref _seed);
        meshFilter.mesh = planetMesh;

        var meshCollider = GetComponent<MeshCollider>();
        meshCollider.sharedMesh = planetMesh;

        Tiles = PlanetGenerator.GetTiles(planetMesh);
    }
}
