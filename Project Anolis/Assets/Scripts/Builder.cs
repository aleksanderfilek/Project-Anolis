using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    public void Build(ref Tile targetTile, GameObject buildingPrefab, ObjectType buildingID)
    {
        var tile = targetTile;

        if (tile.objectType != ObjectType.None)
        {
            Debug.Log("Can't build! The tile is not empty. There is " + tile.objectType + " here.");
            return;
        }

        tile.objectPlaced = Instantiate(buildingPrefab, this.transform);
        tile.objectType = buildingID;

        // position
        tile.objectPlaced.transform.Translate(tile.position, Space.Self);

        // rotation
        tile.objectPlaced.transform.rotation = Quaternion.LookRotation(tile.normal);
        tile.objectPlaced.transform.Rotate(new Vector3(90, 0, 0), Space.Self);

        targetTile = tile;
    }

    public void Destroy(ref Tile targetTile)
    {
        var tile = targetTile;

        if(tile.objectType <= ObjectType.BuildableFlag)
        {
            Debug.Log("Can't destroy object on this tile. Object " + tile.objectType + " is not a building.");
            return;
        }

        Destroy(tile.objectPlaced);
        tile.objectType = ObjectType.None;

        targetTile = tile;
    }
}
