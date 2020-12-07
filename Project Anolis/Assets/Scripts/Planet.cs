using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class Planet : MonoBehaviour
{
    [SerializeField] [Range(1,100)] private int resolution = 1;

    public Tile[] Tiles { get; private set; }
    public float Radius { get; set; }

    private MeshFilter _meshFilter;
    private MeshCollider _meshCollider;

    private int _previousFrameResolution; // used for real-time generation

    public void RecreateWith(int res)
    {
        this.resolution = res;
        _meshFilter = GetComponent<MeshFilter>();
        _meshCollider = GetComponent<MeshCollider>();
        Initialize();
    }
    
    private void Start()
    {
        _meshFilter = GetComponent<MeshFilter>();
        _meshCollider = GetComponent<MeshCollider>();
        Initialize();
        _previousFrameResolution = resolution;
    }

    private void Update()
    {
        if (resolution != _previousFrameResolution)
        {
            Initialize();
        }
        _previousFrameResolution = resolution;
    }

    private void Initialize()
    {
        var planetMesh = PlanetGenerator.Generate(resolution);
        
        _meshFilter.mesh.Clear();
        _meshFilter.mesh = planetMesh;
        
        _meshCollider.sharedMesh = planetMesh;
        
        Tiles = PlanetGenerator.GetTiles(_meshFilter.sharedMesh);
        Radius = _meshFilter.sharedMesh.vertices[0].magnitude;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        if (_meshFilter == null) return;
        foreach (var vertex in _meshFilter.sharedMesh.vertices)
        {
            Gizmos.DrawSphere(vertex + transform.position, 0.2f);
        }
    }
}