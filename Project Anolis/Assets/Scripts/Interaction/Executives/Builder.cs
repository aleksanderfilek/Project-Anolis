﻿using UnityEngine;

namespace Interaction
{
    //todo document
    public class Builder : MonoBehaviour
    {
        public void Build(Placeable building, Tile tile, Transform planetTransform)
        {
            if (tile.TileContent != null)
            {
                Destroy(tile.TileContent);
            }
            
            tile.TileContent = Instantiate(building.prefab, planetTransform);
            
            tile.TileContent.transform.Translate(tile.Position, Space.Self);
            tile.TileContent.transform.rotation = Quaternion.LookRotation(tile.Position);
            tile.TileContent.transform.Rotate(new Vector3(90, 0, 0), Space.Self);
            
            tile.TileContent.AddComponent<PlaceableInstance>();
            tile.TileContent.GetComponent<PlaceableInstance>().Tile = tile;
            tile.TileContent.tag = "Placeable";
        }
        public void Destroy(Tile tile)
        {
            Destroy(tile.TileContent);
            tile.TileContent = null;
        }
    }
}