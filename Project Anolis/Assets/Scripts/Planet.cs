using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class Planet : MonoBehaviour
{
    [SerializeField] private int _iterations = 0;
    [SerializeField] private float _intensity = 0.1f;
    [SerializeField] private int _seed = -1;

    public Tile[] Tiles { get; private set; }
    public bool IsSelected { get; set; }

    private void Start()
    {
        var meshFilter = GetComponent<MeshFilter>();

        var planetMesh = PlanetGenerator.Generate(_iterations, _intensity, ref _seed);

        meshFilter.mesh = planetMesh;

        var meshCollider = GetComponent<MeshCollider>();
        meshCollider.sharedMesh = planetMesh;

        Tiles = PlanetGenerator.GetTiles(planetMesh);
    }
}