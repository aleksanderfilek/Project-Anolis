using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace Logistics
{
    public class BuildMenu : RadialMenu
    {
        private Builder _builder;
        [SerializeField] private List<Placeable> _buildingList;
        private Tile _selectedTile;
        private Transform _selectedPlanetTransform;

        public override void Show()
        {
            Debug.Log("Showing Build Menu");
            _selectedTile = UnoptimalTileSelector.ExtractTileFromPlanet(Raycast.HitData);
            _selectedPlanetTransform = UnoptimalTileSelector.ExtractTransformFromPlanet(Raycast.HitData);
;
        }

        protected override void Awake()
        {
            _builder = GetComponent<Builder>();
            base.Awake();
        }

        public override void ManageClick()
        {
            _builder.Build(_buildingList[0], _selectedTile, _selectedPlanetTransform);
            Hide();
        }

        public override bool CheckIfValidForSelection()
        {
            var tile = UnoptimalTileSelector.ExtractTileFromPlanet(Raycast.HitData);
            return tile.TileContent == null;
        }
    }
}