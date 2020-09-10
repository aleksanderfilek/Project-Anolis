using System;
using UnityEngine;

namespace Logistics
{
    public class TileSelector : MonoBehaviour
    {
        public Tile SelectedTile { get; private set; }
        public Transform SelectedPlanetTransform { get; private set; }

        public void SelectFromRaycast(RaycastHit hitData)
        {
            if (hitData.transform.CompareTag("Planet"))
                ExtractTileFromPlanet(hitData);
            //if (hitData.transform.CompareTag("TileContent"))
                //ExtractTileFromTileContent(hitData);
            else throw new NoTileSelected();
        }

        private void ExtractTileFromPlanet(RaycastHit hitData)
        {
            SelectedPlanetTransform = hitData.transform;
            var planet = hitData.transform.gameObject.GetComponent<Planet>();
            SelectedTile = planet.Tiles[hitData.triangleIndex];
        }

        private void ExtractTileFromTileContent(RaycastHit hitData)
        {
            throw new NotImplementedException();
        }
    }
}
