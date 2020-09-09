using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logistics
{
    public class BuildMenu : RadialMenu
    {
        public override void Show()
        {
            Debug.Log("Showing Build Menu");
        }

        public override void ManageClick()
        {
            Hide();
        }

        public override bool CheckIfValidForSelection()
        {
            var tile = TileSelector.SelectFromRaycast(Raycast.HitData);
            return tile.IsEmpty();
        }
    }
}