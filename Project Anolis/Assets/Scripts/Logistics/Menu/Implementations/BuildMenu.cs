using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace Logistics
{
    public class BuildMenu : RadialMenu
    {
        private Builder _builder;
        private TileSelector _tileSelector;
        private PlanetSelector _planetSelector;
        [SerializeField] private List<Placeable> _buildingList;

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

        public override bool CheckIfValidForSelection()
        {
            if (_tileSelector.SelectedTile == null)
                return false;
            return _tileSelector.SelectedTile.TileContent == null;
        }
    }
}