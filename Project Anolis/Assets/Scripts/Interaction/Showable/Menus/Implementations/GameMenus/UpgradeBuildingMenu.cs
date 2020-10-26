using UnityEngine;

namespace Interaction
{
    public class UpgradeBuildingMenu : UnderMouseMenu
    {
        [SerializeField] private Builder _builder;
        [SerializeField] private TileSelector _tileSelector;

        public override bool CanHandleSelection()
        {
            if (_tileSelector.SelectedTile == null)
                return false;
            return _tileSelector.SelectedTile.TileContent != null;
        }

        public void RemoveBuilding()
        {
            _builder.Destroy(_tileSelector.SelectedTile);
        }
    }
}