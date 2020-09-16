using System;
using UnityEngine;

namespace Logistics
{
    public class Builder : MonoBehaviour
    {

        public void Build(Placeable building, Tile tile, Transform planetTransform)
        {
            try
            {
                tile.TileContent = Instantiate(building.prefab, planetTransform);

                // position
                tile.TileContent.transform.Translate(tile.Position, Space.Self);
                // rotation
                tile.TileContent.transform.rotation = Quaternion.LookRotation(tile.Position);
                tile.TileContent.transform.Rotate(new Vector3(90, 0, 0), Space.Self);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }

        public void Destroy(Tile tile)
        {
            try
            {
                Destroy(tile.TileContent);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
    }
}