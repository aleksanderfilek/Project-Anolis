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
            ValidateSelection();
            var hitData = Raycast.HitData;
            var planet = hitData.transform.gameObject.GetComponent<Planet>();
            SelectedTile = planet.Tiles[hitData.triangleIndex];
        }

        private void ValidateSelection()
        {
            if (!Raycast.HitData.transform.CompareTag("Planet"))
                throw new NoTileSelected();
        }
    }

    class NoTileSelected : Exception
    { }
}