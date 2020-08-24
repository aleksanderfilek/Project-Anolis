using System.Dynamic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(Builder))]
public class Planet : MonoBehaviour
{
    [SerializeField] private int _iterations = 0;
    [SerializeField] private float _intensivity = 0.1f;
    [SerializeField] private int _seed = -1;

    [SerializeField] GameObject buildingA;
    [SerializeField] GameObject buildingB;

    public Tile[] Tiles { get; private set; }

    private Builder buildingManager;

    private void Start()
    {
        var meshFilter = GetComponent<MeshFilter>();
        var planetMesh = PlanetGenerator.Generate(_iterations, _intensivity, ref _seed);
        meshFilter.mesh = planetMesh;

        var meshCollider = GetComponent<MeshCollider>();
        meshCollider.sharedMesh = planetMesh;

        Tiles = PlanetGenerator.GetTiles(planetMesh);

        buildingManager = GetComponent<Builder>();
    }

    private void Update()
    {
        int testID = UnityEngine.Random.Range(0, Tiles.Length);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            buildingManager.Build(ref Tiles[testID], buildingA, ObjectType.BuildingA);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            buildingManager.Build(ref Tiles[testID], buildingB, ObjectType.BuildingB);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            buildingManager.Destroy(ref Tiles[testID]);
        }
    }
}