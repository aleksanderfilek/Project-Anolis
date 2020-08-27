using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Builder : MonoBehaviour
{
    private List<TileScriptableObject> buildings;

    private void Start()
    {
        buildings = LoadBuildings();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Build("Headquarters");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Build("Warehouse");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Destroy();
        }
    }

    private List<TileScriptableObject> LoadBuildings()
    {
        var objectsArray = Resources.FindObjectsOfTypeAll<TileScriptableObject>();
        var buildingList = objectsArray.Where(t => t.objectType == ObjectType.Building).ToList();
        Debug.Log("Found " + buildingList.Count + " buildings.");
        return buildingList;
    }

    private void Build(string buildingName)
    {
        var tile = TileSelector.FromMousePosition(Input.mousePosition);

        var prefab = FindPrefabByName(buildingName);

        tile.objectPlaced = Instantiate(prefab, this.transform);

        // position
        tile.objectPlaced.transform.Translate(tile.position, Space.Self);

        // rotation
        tile.objectPlaced.transform.rotation = Quaternion.LookRotation(tile.normal);
        tile.objectPlaced.transform.Rotate(new Vector3(90, 0, 0), Space.Self);
    }

    private void Destroy()
    {
        var tile = TileSelector.FromMousePosition(Input.mousePosition);
        Destroy(tile.objectPlaced);
    }

    private GameObject FindPrefabByName(string name)
    {
        GameObject prefab = null;

        foreach (var t in buildings)
        {
            if (t.objectName == name)
            {
                prefab = t.prefab;
                break;
            }
        }

        if (prefab != null)
        {
            return prefab;
        }

        Debug.Log("[Error] Could not find object '" + name + "'. Using default instead.");
        return buildings[0].prefab;
    }
}