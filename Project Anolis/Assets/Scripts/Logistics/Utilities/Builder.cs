using System;
using UnityEngine;

namespace Logistics
{
    public class Builder : MonoBehaviour
    {

        public void Build(Placeable building, Tile tile, Transform planetTransform)
        {
                tile.TileContent = Instantiate(building.prefab, planetTransform);

                // position
                tile.TileContent.transform.Translate(tile.Position, Space.Self);
                // rotation
                tile.TileContent.transform.rotation = Quaternion.LookRotation(tile.Position);
                tile.TileContent.transform.Rotate(new Vector3(90, 0, 0), Space.Self);
        }

        public void Destroy(Tile tile)
        {
                Destroy(tile.TileContent);
                tile.TileContent = null;
        }
    }
}