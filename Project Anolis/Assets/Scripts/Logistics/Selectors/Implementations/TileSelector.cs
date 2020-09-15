using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Logistics
{
    public class TileSelector : Selector
    {
        public Tile SelectedTile { get; set; }

        public override void UpdateSelector()
        {
            if (!isValidForSelection())
                return;
            var hitData = Raycast.HitData;
            var planet = hitData.transform.gameObject.GetComponent<Planet>();
            SelectedTile = planet.Tiles[hitData.triangleIndex];
        }

        private bool isValidForSelection()
        {
            return Raycast.IsSomethingHit && Raycast.HitData.transform.CompareTag("Planet");
        }
    }

    class NoTileSelected : Exception
    { }
}