using System;
using UnityEngine;
using System.Collections.Generic;

public class Builder : MonoBehaviour
{

    private void Build(TileContent building, ref Tile tile, Transform planetTransform)
    {
        try
        {
            tile.objectName = building.objectName;
            tile.objectType = building.objectType;
            tile.objectPlaced = Instantiate(building.prefab, planetTransform);

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

    private void Destroy(ref Tile tile)
    {
        try
        {
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