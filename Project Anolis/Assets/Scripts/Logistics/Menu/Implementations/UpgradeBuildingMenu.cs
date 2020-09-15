using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logistics
{
    public class UpgradeBuildingMenu : Menu
    {
        private Builder _builder;
        private TileSelector _tileSelector;
        private Tile _selectedTile;

        public override void Show()
        {
            Debug.Log("Showing Upgrade Menu");
            _selectedTile = _tileSelector.SelectedTile;
        }

        protected override void Awake()
        {
            _builder = GetComponentInChildren<Builder>();
            _tileSelector = GetComponentInChildren<TileSelector>();
            base.Awake();
        }

        public override void ManageClick()
        {
            _builder.Destroy(_selectedTile);
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