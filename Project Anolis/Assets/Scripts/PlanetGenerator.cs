using System.Collections.Generic;
using UnityEngine;

public static class PlanetGenerator
{
    // creates a planet of given radius
    // iteratively subdivides a suface desired times
    // and randomises heights of vertices seed and with given intensivity
    // intensivity = 0 skips randomizing
    // seed = -1 leaves it random
    public static Mesh Generate(int iterations, float intensivity, ref int seed)
    {
        const float tileSize = 2.5f;

        List<Vector3> vertexList = new List<Vector3>();
        List<Vector3Int> triangleList = new List<Vector3Int>(); 
        Mesh planetMesh = new Mesh();

        float t = (1f + Mathf.Sqrt(5f)) / 2f;
        float radius = Mathf.Pow(2, iterations) * tileSize;

        Initialize(vertexList, triangleList, radius);
        if(iterations > 0)
            Subdivide(iterations, vertexList, ref triangleList, radius);
        if(intensivity > 0f)
            Randomize(vertexList, radius, intensivity, ref seed);
        BuildSphere(planetMesh, vertexList, triangleList);

        return planetMesh;
    }

    // returns initiated Tile info array using existing Mesh
    public static Tile[] GetTiles(Mesh planetMesh)
    {
        var vertices = planetMesh.vertices;
        int tileCount = vertices.Length / 3;
        var tiles = new Tile[tileCount];

        for (int i = 0; i < tileCount; i++)
        {
            Vector3 a = vertices[3 * i + 0];
            Vector3 b = vertices[3 * i + 1];
            Vector3 c = vertices[3 * i + 2];

            Vector3 ab = b - a;
            Vector3 bc = c - b;

            var neighbors = GetNeighbors(i, vertices);

            tiles[i] = new Tile
            {
                position = (a + b + c) / 3,
                normal = Vector3.Cross(ab, bc).normalized,
                objectName = "",
                objectType = ObjectType.None,
                terrainType = TerrainType.Habitable,
                neighbor1 = neighbors[0],
                neighbor2 = neighbors[1],
                neighbor3 = neighbors[2]
            };
        }

        return tiles;
    }

    // creates an icosahedron of given radius (distance from (0,0,0) to vertex)
    private static void Initialize(List<Vector3> vertexList, List<Vector3Int> triangleList, float radius)
    {
        float t = (1f + Mathf.Sqrt(5f)) / 2f;

        vertexList.Add(new Vector3(-1, t, 0).normalized * radius);
        vertexList.Add(new Vector3(1, t, 0).normalized * radius);
        vertexList.Add(new Vector3(-1, -t, 0).normalized * radius);
        vertexList.Add(new Vector3(1, -t, 0).normalized * radius);

        vertexList.Add(new Vector3(0, -1, t).normalized * radius);
        vertexList.Add(new Vector3(0, 1, t).normalized * radius);
        vertexList.Add(new Vector3(0, -1, -t).normalized * radius);
        vertexList.Add(new Vector3(0, 1, -t).normalized * radius);

        vertexList.Add(new Vector3(t, 0, -1).normalized * radius);
        vertexList.Add(new Vector3(t, 0, 1).normalized * radius);
        vertexList.Add(new Vector3(-t, 0, -1).normalized * radius);
        vertexList.Add(new Vector3(-t, 0, 1).normalized * radius);

        triangleList.Add(new Vector3Int(0, 11, 5));
        triangleList.Add(new Vector3Int(0, 5, 1));
        triangleList.Add(new Vector3Int(0, 1, 7));
        triangleList.Add(new Vector3Int(0, 7, 10));
        triangleList.Add(new Vector3Int(0, 10, 11));

        triangleList.Add(new Vector3Int(1, 5, 9));
        triangleList.Add(new Vector3Int(5, 11, 4));
        triangleList.Add(new Vector3Int(11, 10, 2));
        triangleList.Add(new Vector3Int(10, 7, 6));
        triangleList.Add(new Vector3Int(7, 1, 8));

        triangleList.Add(new Vector3Int(3, 9, 4));
        triangleList.Add(new Vector3Int(3, 4, 2));
        triangleList.Add(new Vector3Int(3, 2, 6));
        triangleList.Add(new Vector3Int(3, 6, 8));
        triangleList.Add(new Vector3Int(3, 8, 9));

        triangleList.Add(new Vector3Int(4, 9, 5));
        triangleList.Add(new Vector3Int(2, 4, 11));
        triangleList.Add(new Vector3Int(6, 2, 10));
        triangleList.Add(new Vector3Int(8, 6, 7));
        triangleList.Add(new Vector3Int(9, 8, 1));
    }

    // divides each triangle iteratively into 4 triangles 
    // and moves new vertices to be in desired radius from zero point
    private static void Subdivide(int numOfIterations, List<Vector3> vertexList, ref List<Vector3Int> triangleList, float radius)
    {
        Dictionary<long, int> cache = new Dictionary<long, int>();
        for(int iteration=0; iteration < numOfIterations; iteration++)
        {
            var newTriangleList = new List<Vector3Int>();
            foreach(var triangle in triangleList)
            {
                int a = GetMidPoint(triangle.x, triangle.y, ref vertexList, ref cache, radius);
                int b = GetMidPoint(triangle.y, triangle.z, ref vertexList, ref cache, radius);
                int c = GetMidPoint(triangle.z, triangle.x, ref vertexList, ref cache, radius);

                newTriangleList.Add(new Vector3Int(triangle.x, a, c));
                newTriangleList.Add(new Vector3Int(triangle.y, b, a));
                newTriangleList.Add(new Vector3Int(triangle.z, c, b));
                newTriangleList.Add(new Vector3Int(a, b, c));
            }
            triangleList = newTriangleList;
        }
    }

    // applies noise to each vertex distance from the middle of sphere
    private static void Randomize(List<Vector3> vertexList, float radius, float intensivity, ref int seed)
    {
        if (seed != -1) Random.InitState(seed);

        for(int i=0; i<vertexList.Count; i++)
        {
            vertexList[i] *= Random.Range(1 - intensivity, 1 + intensivity);
        }
    }

    // builds arrays of vertices and triangles using references to achieve flat shading
    // and applies new arrays to target mesh
    private static void BuildSphere(Mesh targetMesh, List<Vector3> vertexList, List<Vector3Int> triangleList)
    {
        List<Vector3> newVertexList = new List<Vector3>();
        int[] indices = new int[triangleList.Count * 3];

        for (int i = 0; i < indices.Length; i += 3)
        {
            indices[i + 0] = i + 0;
            indices[i + 1] = i + 1;
            indices[i + 2] = i + 2;

            newVertexList.Add(vertexList[triangleList[i / 3].x]);
            newVertexList.Add(vertexList[triangleList[i / 3].y]);
            newVertexList.Add(vertexList[triangleList[i / 3].z]);
        }

        targetMesh.Clear();
        targetMesh.vertices = newVertexList.ToArray();
        targetMesh.triangles = indices;
        targetMesh.RecalculateNormals();
        targetMesh.Optimize();
    }

    private static int GetMidPoint(int p1, int p2, ref List<Vector3> vertexList, ref Dictionary<long, int> cache, float radius)
    {
        bool isFirstSmaller = p1 < p2;
        long smallerIndex = isFirstSmaller ? p1 : p2;
        long greaterIndex = isFirstSmaller ? p2 : p1;
        long key = (smallerIndex << 32) + greaterIndex;

        int ret;
        if(cache.TryGetValue(key, out ret))
        {
            return ret;
        }

        Vector3 point1 = vertexList[p1];
        Vector3 point2 = vertexList[p2];
        Vector3 middle = new Vector3((point1.x + point2.x) / 2f, (point1.y + point2.y) / 2f, (point1.z + point2.z) / 2f);

        int i = vertexList.Count;
        vertexList.Add(middle.normalized * radius);
        cache.Add(key, i);

        return i;
    }

    private static int[] GetNeighbors(int thisTriangleID, Vector3[] vertices)
    {
        // I just want it working
        
        var neighborIDs = new int[3];
        int numOfNeighborsFound = 0;
        
        var thisVertices = new Vector3[3];
        thisVertices[0] = vertices[3 * thisTriangleID + 0];
        thisVertices[1] = vertices[3 * thisTriangleID + 1];
        thisVertices[2] = vertices[3 * thisTriangleID + 2];

        for (int i = 0; i < vertices.Length/3; i++)
        {
            if (i == thisTriangleID) continue;

            var anotherVertices = new Vector3[3];
            anotherVertices[0] = vertices[3 * i + 0];
            anotherVertices[1] = vertices[3 * i + 1];
            anotherVertices[2] = vertices[3 * i + 2];
            
            if (IsNeighbor(thisVertices, anotherVertices))
            {
                neighborIDs[numOfNeighborsFound] = i;
                numOfNeighborsFound ++;
            }
        }

        return neighborIDs;
    }

    private static bool IsNeighbor(Vector3[] triangle1, Vector3[] triangle2)
    {

        var a1 = triangle1[0];
        var a2 = triangle1[1];
        var a3 = triangle1[2];
        
        var b1 = triangle2[0];
        var b2 = triangle2[1];
        var b3 = triangle2[2];

        if (a1 == b1 || a1 == b2 || a1 == b3) // is a1 in arr b?
        {
            if (a2 == b1 || a2 == b2 || a2 == b3) // is a2 in arr b?
            {
                if (a3 == b1 || a3 == b2 || a3 == b3) // is a3 in arr b?
                {
                    return false;
                }

                return true;
            }

            if (a3 == b1 || a3 == b2 || a3 == b3) // is a3 in arr b?
            {
                return true;
            }

            return false;
        }

        if (a2 == b1 || a2 == b2 || a2 == b3) // is a2 in arr b?
        {
            if (a3 == b1 || a3 == b2 || a3 == b3) // is a3 in arr b?
            {
                return true;
            }

            return false;
        }

        return false;
    }
}
