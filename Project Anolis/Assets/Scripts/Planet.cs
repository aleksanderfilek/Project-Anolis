using System.Dynamic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class Planet : MonoBehaviour
{
    [SerializeField] private int _iterations = 0;
    [SerializeField] private float _intensivity = 0.1f;
    [SerializeField] private int _seed = -1;

    [SerializeField] GameObject buildingA;
    [SerializeField] GameObject buildingB;

    public Tile[] Tiles { get; private set; }

    private void Start()
    {
        var meshFilter = GetComponent<MeshFilter>();
        var planetMesh = PlanetGenerator.Generate(_iterations, _intensivity, ref _seed);
        meshFilter.mesh = planetMesh;

        var meshCollider = GetComponent<MeshCollider>();
        meshCollider.sharedMesh = planetMesh;

        Tiles = PlanetGenerator.GetTiles(planetMesh);
    }

    private void Update()
    {
        int testID = UnityEngine.Random.Range(0, Tiles.Length);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Build(testID, ObjectType.BuildingA, buildingA);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Build(testID, ObjectType.BuildingB, buildingB);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Destroy(testID);
        }
    }

    private void Build(int tileID, ObjectType name, GameObject prefab)
    {
        var tile = Tiles[tileID];

        if (tile.objectType != ObjectType.None)
        {
            print("You can't build that here!");
            return;
        }

        tile.objectPlaced = Instantiate(prefab, this.transform);
        tile.objectType = name;

        // position
        tile.objectPlaced.transform.Translate(tile.position, Space.Self);

        // rotation
        tile.objectPlaced.transform.rotation = Quaternion.LookRotation(tile.normal);
        tile.objectPlaced.transform.Rotate(new Vector3(90, 0, 0), Space.Self);

        // scale
        // tile.objectPlaced.transform.localScale = new Vector3(.1f, .1f, .1f);

        Tiles[tileID] = tile;
    }

    private void Destroy(int tileID)
    {
        var tile = Tiles[tileID];

        Destroy(tile.objectPlaced);
        tile.objectType = ObjectType.None;

        Tiles[tileID] = tile;
    }
}