using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter))]
public class Planet : MonoBehaviour
{
    public float radius = 1f;
    public int iterations = 1;
    public float intensivity = 0.1f;
    public int seed = -1;

    private Tile[] tiles;

    public void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh planetMesh = PlanetGenerator.Generate(radius, iterations, intensivity, ref seed);
        meshFilter.mesh = planetMesh;

        tiles = PlanetGenerator.GetTiles(planetMesh);
    }
}
