using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logistics
{
    public class UpgradeBuildingMenu : Menu
    {
        private Builder _builder;
        private TileSelector _tileSelector;

        public override void Show()
        {
            Debug.Log("Showing Upgrade Menu");
        }

        protected override void Awake()
        {
            _builder = GetComponentInChildren<Builder>();
            _tileSelector = GetComponentInChildren<TileSelector>();
            base.Awake();
        }

        public override void ManageClick()
        {
            _builder.Destroy(_tileSelector.SelectedTile);
            Hide();
        }

        public override bool CheckIfValidForSelection()
        {
            if (_tileSelector.SelectedTile == null)
                return false;
            var tile = _tileSelector.SelectedTile;
            return tile.TileContent != null;
        }
    }
}