using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public static class PlanetGenerator
{
    public struct Triangle
    {
        public int v1, v2, v3;

        public Triangle(int v1, int v2, int v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }
    }

    static float _radius = 1f;
    static int _iterations = 0;

    static List<Vector3> _verticesList;
    static List<Triangle> _trianglesList;

    public static Mesh Create(float radius, int iterations)
    {
        _radius = radius;
        _iterations = iterations;

        Initialize();
        SeparateTriangles();
        Subdivide();

        Mesh planetMesh = new Mesh();

        planetMesh.Clear();
        planetMesh.vertices = _verticesList.ToArray();
        List<int> indices = new List<int>();
        foreach (var trinagle in _trianglesList)
        {
            indices.Add(trinagle.v1);
            indices.Add(trinagle.v2);
            indices.Add(trinagle.v3);
        }
        planetMesh.triangles = indices.ToArray();
        planetMesh.RecalculateNormals();

        return planetMesh;
    }

    static void Initialize()
    {
        _verticesList = new List<Vector3>();
        _trianglesList = new List<Triangle>();

        float t = (1f + Mathf.Sqrt(5f)) / 2f;

        _verticesList.Add(new Vector3(-1, t, 0).normalized * _radius);
        _verticesList.Add(new Vector3(1, t, 0).normalized * _radius);
        _verticesList.Add(new Vector3(-1, -t, 0).normalized * _radius);
        _verticesList.Add(new Vector3(1, -t, 0).normalized * _radius);

        _verticesList.Add(new Vector3(0, -1, t).normalized * _radius);
        _verticesList.Add(new Vector3(0, 1, t).normalized * _radius);
        _verticesList.Add(new Vector3(0, -1, -t).normalized * _radius);
        _verticesList.Add(new Vector3(0, 1, -t).normalized * _radius);

        _verticesList.Add(new Vector3(t, 0, -1).normalized * _radius);
        _verticesList.Add(new Vector3(t, 0, 1).normalized * _radius);
        _verticesList.Add(new Vector3(-t, 0, -1).normalized * _radius);
        _verticesList.Add(new Vector3(-t, 0, 1).normalized * _radius);

        _trianglesList.Add(new Triangle(0, 11, 5));
        _trianglesList.Add(new Triangle(0, 5, 1));
        _trianglesList.Add(new Triangle(0, 1, 7));
        _trianglesList.Add(new Triangle(0, 7, 10));
        _trianglesList.Add(new Triangle(0, 10, 11));

        _trianglesList.Add(new Triangle(1, 5, 9));
        _trianglesList.Add(new Triangle(5, 11, 4));
        _trianglesList.Add(new Triangle(11, 10, 2));
        _trianglesList.Add(new Triangle(10, 7, 6));
        _trianglesList.Add(new Triangle(7, 1, 8));

        _trianglesList.Add(new Triangle(3, 9, 4));
        _trianglesList.Add(new Triangle(3, 4, 2));
        _trianglesList.Add(new Triangle(3, 2, 6));
        _trianglesList.Add(new Triangle(3, 6, 8));
        _trianglesList.Add(new Triangle(3, 8, 9));

        _trianglesList.Add(new Triangle(4, 9, 5));
        _trianglesList.Add(new Triangle(2, 4, 11));
        _trianglesList.Add(new Triangle(6, 2, 10));
        _trianglesList.Add(new Triangle(8, 6, 7));
        _trianglesList.Add(new Triangle(9, 8, 1));
    }

    static void SeparateTriangles()
    {
        // first clone vertices to have unique one for each triangle
        // each vertex makes 6 triangles
        int numOfVertices = _verticesList.Count;
        for (int i = 0; i < 5; i++)
            for(int j=0; j<numOfVertices; j++)
                _verticesList.Add(_verticesList[j]);

        // now triangles
        // to make sure we used unique vertex we need additional array
        // it keep info about number of usages for each vertex
        int[] usagesCounter = new int[_verticesList.Count / 6];
        for(int i=0; i<_trianglesList.Count; i++)
        {
            int indexV1 = _trianglesList[i].v1;
            int indexV2 = _trianglesList[i].v2;
            int indexV3 = _trianglesList[i].v3;

            usagesCounter[indexV1]++;
            indexV1 += usagesCounter[indexV1] * usagesCounter.Length;
            usagesCounter[indexV2]++;
            indexV2 += usagesCounter[indexV2] * usagesCounter.Length;
            usagesCounter[indexV3]++;
            indexV3 += usagesCounter[indexV3] * usagesCounter.Length;

            _trianglesList[i] = new Triangle(indexV1, indexV2, indexV3);
        }
    }

    static void Subdivide()
    {

    }
}
