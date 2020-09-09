using System;
using UnityEngine;

namespace Logistics
{
    public class TileSelector
    {
        public static ref Tile SelectFromRaycast(RaycastHit hitData)
        {
            if (hitData.transform.CompareTag("Planet"))
                return ref ExtractTileFromPlanet(hitData);
            if (hitData.transform.CompareTag("TileContent"))
                return ref ExtractTileFromTileContent(hitData);
            throw new NoTileSelected();
        }

        private static ref Tile ExtractTileFromPlanet(RaycastHit hitData)
        {
            var planet = hitData.transform.gameObject.GetComponent<Planet>();
            return ref planet.Tiles[hitData.triangleIndex];
        }

        private static ref Tile ExtractTileFromTileContent(RaycastHit hitData)
        {
            throw new NotImplementedException();
        }
    }

    class NoTileSelected : Exception
    { }
}
