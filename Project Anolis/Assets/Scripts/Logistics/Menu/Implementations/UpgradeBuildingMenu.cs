using UnityEngine;

namespace Logistics
{
    public class UpgradeBuildingMenu : UnderMouseMenu
    {
        private Builder _builder;
        private TileSelector _tileSelector;

        protected override void Awake()
        {
            _builder = GetComponentInChildren<Builder>();
            _tileSelector = GetComponentInChildren<TileSelector>();
            base.Awake();
        }

        public override bool CanHandleSelection()
        {
            if (_tileSelector.SelectedTile == null)
                return false;
            return _tileSelector.SelectedTile.TileContent != null;
        }

        public void RemoveBuilding()
        {
            _builder.Destroy(_tileSelector.SelectedTile);
            Hide();
        }
    }
}