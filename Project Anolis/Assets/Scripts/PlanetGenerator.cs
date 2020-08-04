using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public static class PlanetGenerator
{
    static List<Vector3> _verticesList;
    static List<Vector3Int> _trianglesList; // each object keeps 3 vertex indices

    public static Mesh Create(float radius, int iterations)
    {
        Initialize(radius);
        Subdivide();

        Mesh planetMesh = new Mesh();

        planetMesh.Clear();
        planetMesh.vertices = _verticesList.ToArray();
        List<int> indices = new List<int>();
        foreach (var trinagle in _trianglesList)
        {
            indices.Add(trinagle.x);
            indices.Add(trinagle.y);
            indices.Add(trinagle.z);
        }
        planetMesh.triangles = indices.ToArray();
        planetMesh.RecalculateNormals();

        return planetMesh;
    }

    // creates a set of sepearate triangles creating icosahedron
    static void Initialize(float radius)
    {
        _verticesList = new List<Vector3>();
        _trianglesList = new List<Vector3Int>();

        float t = (1f + Mathf.Sqrt(5f)) / 2f;
        List<Vector3> tVectors = new List<Vector3>();

        tVectors.Add(new Vector3(-1, t, 0).normalized * radius);
        tVectors.Add(new Vector3(1, t, 0).normalized * radius);
        tVectors.Add(new Vector3(-1, -t, 0).normalized * radius);
        tVectors.Add(new Vector3(1, -t, 0).normalized * radius);

        tVectors.Add(new Vector3(0, -1, t).normalized * radius);
        tVectors.Add(new Vector3(0, 1, t).normalized * radius);
        tVectors.Add(new Vector3(0, -1, -t).normalized * radius);
        tVectors.Add(new Vector3(0, 1, -t).normalized * radius);

        tVectors.Add(new Vector3(t, 0, -1).normalized * radius);
        tVectors.Add(new Vector3(t, 0, 1).normalized * radius);
        tVectors.Add(new Vector3(-t, 0, -1).normalized * radius);
        tVectors.Add(new Vector3(-t, 0, 1).normalized * radius);

        AddTriangle(tVectors[0], tVectors[11], tVectors[5]);
        AddTriangle(tVectors[0], tVectors[5], tVectors[1]);
        AddTriangle(tVectors[0], tVectors[1], tVectors[7]);
        AddTriangle(tVectors[0], tVectors[7], tVectors[10]);
        AddTriangle(tVectors[0], tVectors[10], tVectors[11]);

        AddTriangle(tVectors[1], tVectors[5], tVectors[9]);
        AddTriangle(tVectors[5], tVectors[11], tVectors[4]);
        AddTriangle(tVectors[11], tVectors[10], tVectors[2]);
        AddTriangle(tVectors[10], tVectors[7], tVectors[6]);
        AddTriangle(tVectors[7], tVectors[1], tVectors[8]);

        AddTriangle(tVectors[3], tVectors[9], tVectors[4]);
        AddTriangle(tVectors[3], tVectors[4], tVectors[2]);
        AddTriangle(tVectors[3], tVectors[2], tVectors[6]);
        AddTriangle(tVectors[3], tVectors[6], tVectors[8]);
        AddTriangle(tVectors[3], tVectors[8], tVectors[9]);

        AddTriangle(tVectors[4], tVectors[9], tVectors[5]);
        AddTriangle(tVectors[2], tVectors[4], tVectors[11]);
        AddTriangle(tVectors[6], tVectors[2], tVectors[10]);
        AddTriangle(tVectors[8], tVectors[6], tVectors[7]);
        AddTriangle(tVectors[9], tVectors[8], tVectors[1]);
    }

    // iteratively subdivides each triangle into 4 triangles
    static void Subdivide()
    {

    }

    // adds a triangle into the end of lists
    static void AddTriangle(Vector3 v1, Vector3 v2, Vector3 v3)
    {
        int idx = _verticesList.Count;
        _verticesList.Add(v1.normalized);
        _verticesList.Add(v2.normalized);
        _verticesList.Add(v3.normalized);
        _trianglesList.Add(new Vector3Int(idx, idx + 1, idx + 2));
    }
}
