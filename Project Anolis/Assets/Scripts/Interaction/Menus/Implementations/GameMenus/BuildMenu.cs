using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public class BuildMenu : UnderMouseMenu
    {
        [SerializeField] private List<Placeable> buildingList;

        [SerializeField] private TileSelector tileSelector;
        [SerializeField] private PlanetSelector planetSelector;
        [SerializeField] private Builder builder;

        public override bool CanHandleSelection()
        {
            if (tileSelector.SelectedTile == null)
                return false;
            return tileSelector.SelectedTile.TileContent == null;
        }

        public void BuildForge()
        {
            Build(0);
        }

        public void BuildSawmill()
        {
            Build(1);
        }

        private void Build(int index)
        {
            builder.Build(buildingList[index], tileSelector.SelectedTile, planetSelector.SelectedPlanet.transform);
        }
    }
}
