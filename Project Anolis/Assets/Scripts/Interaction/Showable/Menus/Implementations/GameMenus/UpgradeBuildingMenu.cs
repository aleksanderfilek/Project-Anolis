using UnityEngine;

namespace Interaction
{
    public class UpgradeBuildingMenu : UnderMouseMenu
    {
        [SerializeField] private Builder builder;
        [SerializeField] private TileSelector tileSelector;

        public override bool CanHandleSelection()
        {
            if (tileSelector.SelectedTile == null)
                return false;
            return tileSelector.SelectedTile.TileContent != null;
        }

        public void RemoveBuilding()
        {
            builder.Destroy(tileSelector.SelectedTile);
        }
    }
}