using System.Collections.Generic;
using UnityEngine;

namespace Logistics
{
    public class BuildMenu : RadialMenu
    {
        [SerializeField] private List<Placeable> _buildingList;

        private Builder _builder;
        private TileSelector _tileSelector;
        private PlanetSelector _planetSelector;

        protected override void Awake()
        {
            _builder = GetComponentInChildren<Builder>();
            _tileSelector = GetComponentInChildren<TileSelector>();
            _planetSelector = GetComponentInChildren<PlanetSelector>();
            base.Awake();
        }

        public override void Show()
        {
            Debug.Log("Showing Build Menu");
        }

        public override void ManageClick()
        {
            _builder.Build(_buildingList[0], _tileSelector.SelectedTile, _planetSelector.SelectedPlanet.transform);
            Hide();
        }

        public override bool IsValidForSelection()
        {
            if (_tileSelector.SelectedTile == null)
                return false;
            return _tileSelector.SelectedTile.TileContent == null;
        }
    }
}