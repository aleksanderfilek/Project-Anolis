using UnityEngine;

namespace Interaction
{
    public class TileSelector : Selector
    {
        public Tile SelectedTile { get; private set; }

        protected override bool IsValidForSelection()
        {
            return raycast.IsSomethingHit 
                   && (raycast.HitData.transform.CompareTag("Planet") 
                       || raycast.HitData.transform.CompareTag("Placeable"));
        }

        protected override void Select()
        {
            var hitData = raycast.HitData;
            if (hitData.transform.CompareTag("Planet"))
            {
                var planet = hitData.transform.gameObject.GetComponent<Planet>();
                SelectedTile = planet.Tiles[hitData.triangleIndex];
                return;
            }
            if (hitData.transform.CompareTag("Placeable"))
            {
                var placeable = hitData.transform.gameObject.GetComponent<PlaceableInstance>();
                SelectedTile = placeable.Tile;
                return;
            }
            Debug.LogError("Tile selection failed");
        }

        protected override void ClearSelection()
        {
            SelectedTile = null;
        }
    }
}