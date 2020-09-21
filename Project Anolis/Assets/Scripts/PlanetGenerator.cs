using System.Collections.Generic;
using UnityEngine;

public static class PlanetGenerator
{
    public static Mesh Generate(int resolution)
    {
        var vertices = new List<Vector3>();
        var triangles = new List<Vector3Int>();

        const float tileSize = 2.5f;
        var radius = resolution * tileSize;

        Initialize(ref vertices, ref triangles, radius);

        Subdivide(ref vertices, ref triangles, resolution, radius);

        var mesh = CreateMesh(ref vertices, ref triangles);
        return mesh;
    }

    public static Tile[] GetTiles(Mesh mesh)
    {
        var vertices = mesh.vertices;
        var triangles = mesh.triangles;
        var tiles = new Tile[triangles.Length / 3];
        
        for (var i = 0; i < triangles.Length; i+=3)
        {
            var a = vertices[triangles[i]];
            var b = vertices[triangles[i + 1]];
            var c = vertices[triangles[i + 2]];
            
            tiles[i / 3] = new Tile((a + b + c) / 3.0f);
        }
        
        return tiles;
    }

    private static void Initialize(ref List<Vector3> vertices, ref List<Vector3Int> triangles, float radius)
    {
        var t = (1f + Mathf.Sqrt(5f)) / 2f;

        var newVertices = new List<Vector3>();
        var newTriangles = new List<Vector3Int>();

        newVertices.Add(new Vector3(-1, t, 0).normalized * radius);
        newVertices.Add(new Vector3(1, t, 0).normalized * radius);
        newVertices.Add(new Vector3(-1, -t, 0).normalized * radius);
        newVertices.Add(new Vector3(1, -t, 0).normalized * radius);

        newVertices.Add(new Vector3(0, -1, t).normalized * radius);
        newVertices.Add(new Vector3(0, 1, t).normalized * radius);
        newVertices.Add(new Vector3(0, -1, -t).normalized * radius);
        newVertices.Add(new Vector3(0, 1, -t).normalized * radius);

        newVertices.Add(new Vector3(t, 0, -1).normalized * radius);
        newVertices.Add(new Vector3(t, 0, 1).normalized * radius);
        newVertices.Add(new Vector3(-t, 0, -1).normalized * radius);
        newVertices.Add(new Vector3(-t, 0, 1).normalized * radius);

        newTriangles.Add(new Vector3Int(0, 11, 5));
        newTriangles.Add(new Vector3Int(0, 5, 1));
        newTriangles.Add(new Vector3Int(0, 1, 7));
        newTriangles.Add(new Vector3Int(0, 7, 10));
        newTriangles.Add(new Vector3Int(0, 10, 11));

        newTriangles.Add(new Vector3Int(1, 5, 9));
        newTriangles.Add(new Vector3Int(5, 11, 4));
        newTriangles.Add(new Vector3Int(11, 10, 2));
        newTriangles.Add(new Vector3Int(10, 7, 6));
        newTriangles.Add(new Vector3Int(7, 1, 8));

        newTriangles.Add(new Vector3Int(3, 9, 4));
        newTriangles.Add(new Vector3Int(3, 4, 2));
        newTriangles.Add(new Vector3Int(3, 2, 6));
        newTriangles.Add(new Vector3Int(3, 6, 8));
        newTriangles.Add(new Vector3Int(3, 8, 9));

        newTriangles.Add(new Vector3Int(4, 9, 5));
        newTriangles.Add(new Vector3Int(2, 4, 11));
        newTriangles.Add(new Vector3Int(6, 2, 10));
        newTriangles.Add(new Vector3Int(8, 6, 7));
        newTriangles.Add(new Vector3Int(9, 8, 1));

        foreach (var triangle in newTriangles)
        {
            var a = newVertices[triangle.x];
            var b = newVertices[triangle.y];
            var c = newVertices[triangle.z];

            var index = vertices.Count;

            vertices.Add(a);
            vertices.Add(b);
            vertices.Add(c);

            triangles.Add(new Vector3Int(index, index + 1, index + 2));
        }
    }

    private static void Subdivide (ref List<Vector3> vertices, ref List<Vector3Int> triangles, int resolution, float radius)
    {
        if (resolution == 1) return;
        
        var newVertices = new List<Vector3>();
        var newTriangles = new List<Vector3Int>();

        foreach (var bigTriangle in triangles)
        {
            var a = vertices[bigTriangle.x];
            var b = vertices[bigTriangle.y];
            var c = vertices[bigTriangle.z];
            
            var points = new Vector3[resolution + 1][];
            for (var i = 0; i <= resolution; i++)
            {
                points[i] = new Vector3[resolution + 1 - i];
            }

            points[0][0] = a;
            points[0][resolution] = b;
            points[resolution][0] = c;

            for (var i = 1; i < resolution; i++)
            {
                var percent = (float) i / resolution;
                points[0][i] = a + (b - a) * percent;
                points[i][0] = a + (c - a) * percent;
                points[i][resolution - i] = b + (c - b) * percent;
            }

            for (var i = 1; i < resolution - 1; i++)
            {
                for (var j = 1; j < resolution - i; j++)
                {
                    var percent = (float) j / (resolution - i);
                    points[i][j] = points[i][0] * (1 - percent) + points[i][resolution - i] * percent;
                }
            }

            for (var i = 0; i < resolution; i++)
            {
                for (var j = 0; j < resolution - i; j++)
                {
                    var index = newVertices.Count;
                    newVertices.Add(points[i][j].normalized * radius);
                    newVertices.Add(points[i][j+1].normalized * radius);
                    newVertices.Add(points[i+1][j].normalized * radius);
                    newTriangles.Add(new Vector3Int(index, index + 1, index + 2));
                }
            }
            
            for (var i = 0; i < resolution - 1; i++)
            {
                for (var j = 1; j < resolution - i; j++)
                {
                    var index = newVertices.Count;
                    newVertices.Add(points[i][j].normalized * radius);
                    newVertices.Add(points[i+1][j].normalized * radius);
                    newVertices.Add(points[i+1][j-1].normalized * radius);
                    newTriangles.Add(new Vector3Int(index, index+1, index+2));
                }
            }
        }
        vertices = newVertices;
        triangles = newTriangles;
    }

    private static Mesh CreateMesh(ref List<Vector3> vertices, ref List<Vector3Int> triangles)
    {
        var indicesCount = triangles.Count * 3;

        var verticesArr = vertices.ToArray();
        var trianglesArr = new int[indicesCount];
        
        for (var i = 0; i < triangles.Count; i++)
        {
            var triangle = triangles[i];
            trianglesArr[3 * i + 0] = triangle.x;
            trianglesArr[3 * i + 1] = triangle.y;
            trianglesArr[3 * i + 2] = triangle.z;
        }

        var mesh = new Mesh { vertices = verticesArr, triangles = trianglesArr};
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        mesh.Optimize();

        return mesh;
    }
}