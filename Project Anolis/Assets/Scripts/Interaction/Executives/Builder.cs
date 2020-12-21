using System;
using UnityEngine;

namespace Interaction
{
    public class Builder : MonoBehaviour
    {

        public void Build(BuildingPlaceable building, Tile tile, Transform planetTransform)
        {
                tile.Content = Instantiate(building.prefab, planetTransform);

                // position
                tile.Content.transform.Translate(tile.Position, Space.Self);
                // rotation
                tile.Content.transform.rotation = Quaternion.LookRotation(tile.Position);
                tile.Content.transform.Rotate(new Vector3(90, 0, 0), Space.Self);
                
                Score.AddScore(-building.cost);
                ResourceWarehouse.UpdateResources(planetTransform.gameObject, (ushort)building.resourceType, 1);
        }

        public void Destroy(Tile tile)
        {
                Destroy(tile.Content);
        }
    }
}