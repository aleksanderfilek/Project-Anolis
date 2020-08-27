using System;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    [SerializeField] private List<TileScriptableObject> buildingList;

    private void Start()
    {
        if (buildingList.Count == 0)
        {
            Debug.Log("[Warn] List of buildings is empty.");
        }
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Build(buildingList[0]);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Build(buildingList[1]);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Destroy();
        }
    }

    private void Build(TileScriptableObject building)
    {
        try
        {
            var tile = TileSelector.FromMousePosition(Input.mousePosition);

            tile.objectName = building.objectName;
            tile.objectType = building.objectType;
            tile.objectPlaced = Instantiate(building.prefab, this.transform);

            // position
            tile.objectPlaced.transform.Translate(tile.position, Space.Self);
            // rotation
            tile.objectPlaced.transform.rotation = Quaternion.LookRotation(tile.normal);
            tile.objectPlaced.transform.Rotate(new Vector3(90, 0, 0), Space.Self);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    private void Destroy()
    {
        try
        {
            var tile = TileSelector.FromMousePosition(Input.mousePosition);

            tile.objectName = "";
            tile.objectType = ObjectType.None;
            Destroy(tile.objectPlaced);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
}