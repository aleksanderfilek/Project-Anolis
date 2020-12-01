using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is a Planet Editor class which generates new planet 
public class PlanetCreator : MonoBehaviour
{
    [SerializeField] private float randRadius;
    [SerializeField] private Vector2Int minMaxSize;
    [SerializeField] private Material defaultMaterial;
    private Vector3 position;
    private int size;

    private void Start()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
    }
    
    public GameObject Create()
    {
        position = new Vector3(Random.value * randRadius, Random.value * 10, Random.value * randRadius);
        size = Random.Range(minMaxSize.x, minMaxSize.y);
        
        var planet = new GameObject {name = "Rand Planet"};
        planet.transform.position = position;
        planet.AddComponent<MeshFilter>();
        planet.AddComponent<MeshCollider>();
        var planetComp = planet.AddComponent<Planet>();
        planet.GetComponent<Renderer>().material = defaultMaterial;
        planetComp.RecreateWith(size);

        return planet;
    }
}
