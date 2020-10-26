using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public class BuildMenu : UnderMouseMenu
    {
        [SerializeField] private List<Placeable> _buildingList;

        [SerializeField] private TileSelector _tileSelector;
        [SerializeField] private PlanetSelector _planetSelector;
        [SerializeField] private Builder _builder;

        public override bool CanHandleSelection()
        {
            if (_tileSelector.SelectedTile == null)
                return false;
            return _tileSelector.SelectedTile.TileContent == null;
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
            _builder.Build(_buildingList[index], _tileSelector.SelectedTile, _planetSelector.SelectedPlanet.transform);
        }
    }
}
