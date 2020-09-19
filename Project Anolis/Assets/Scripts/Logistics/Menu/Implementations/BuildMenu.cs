using System.Collections.Generic;
using UnityEngine;

namespace Logistics
{
    public class BuildMenu : UnderMouseMenu
    {
        [SerializeField] private List<Placeable> _buildingList;

        private TileSelector _tileSelector;
        private PlanetSelector _planetSelector;
        private Builder _builder;

        protected override void Awake()
        {
            _tileSelector = GetComponentInChildren<TileSelector>();
            _planetSelector = GetComponentInChildren<PlanetSelector>();
            _builder = GetComponentInChildren<Builder>();
            base.Awake();
        }

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
            Hide();
        }
    }
}
