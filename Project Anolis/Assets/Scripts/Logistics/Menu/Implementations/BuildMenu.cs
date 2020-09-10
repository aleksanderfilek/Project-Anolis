using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logistics
{
    public class BuildMenu : RadialMenu
    {
        private Builder _builder;
        [SerializeField] private List<TileContent> _buildingList;
        private TileSelector _tileSelector;
        private Tile _selectedTile;
        private Transform _selectedPlanetTransform;

        public override void Show()
        {
            _tileSelector.SelectFromRaycast(Raycast.HitData);
            _selectedTile = _tileSelector.SelectedTile;
            _selectedPlanetTransform = _tileSelector.SelectedPlanetTransform;
            Debug.Log("Showing Build Menu");
        }

        protected override void Awake()
        {
            _tileSelector = GetComponentInChildren<TileSelector>();
            _builder = GetComponent<Builder>();
            base.Awake();
        }

        public override void ManageClick()
        {
            _builder.Build(_buildingList[0], ref _selectedTile, _selectedPlanetTransform);
            Hide();
        }

        public override bool CheckIfValidForSelection()
        {
            _tileSelector.SelectFromRaycast(Raycast.HitData);
            var tile = _tileSelector.SelectedTile;
            return tile.IsEmpty();
        }
    }
}