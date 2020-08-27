using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Builder : MonoBehaviour
{
    [SerializeField] List<TileScriptableObject> buildings;

    private void Start()
    {
        
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

    private void Build(string buildingName)
    {
        var tile = TileSelector.FromMousePosition(Input.mousePosition);

        var prefab = buildings.Find(t => t.objectName == buildingName).prefab;

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
}