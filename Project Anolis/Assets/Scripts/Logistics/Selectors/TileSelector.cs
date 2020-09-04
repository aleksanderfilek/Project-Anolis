using System;
using UnityEngine;

namespace Logistics
{
    public class TileSelector
    {
        public static ref Tile FromMousePosition(Vector3 mousePosition)
        {
            var ray = Camera.main.ScreenPointToRay(mousePosition);
            var isHit = Physics.Raycast(ray, out var hitData, 1000);
            CheckShotResult(isHit, hitData);
            return ref ExtractTile(hitData);
        }

        private static void CheckShotResult(bool isHit, RaycastHit hitData)
        {
            if (!isHit)
                throw new NoTileSelected();
            if (!hitData.transform.CompareTag("Planet"))
                throw new WrongObjectClicked();
        }

        private static ref Tile ExtractTile(RaycastHit hitData)
        {
            var planet = hitData.transform.gameObject.GetComponent<Planet>();
            return ref planet.Tiles[hitData.triangleIndex];
        }
    }

    class NoTileSelected : Exception
    {
    }

    class WrongObjectClicked : NoTileSelected
    {
    }
    
}
