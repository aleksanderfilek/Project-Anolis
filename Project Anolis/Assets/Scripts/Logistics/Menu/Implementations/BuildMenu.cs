using System.Collections.Generic;
using UnityEngine;

namespace Logistics
{
    public class BuildMenu : Menu
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
        
        public override void Show()
        {
            _uiCanvas.enabled = true;

            var halfMenuSize = _uiRadial.rect.size / 2;
            var screenSize = _uiCanvas.pixelRect.size;
            
            var newPosition = Input.mousePosition;

            newPosition.x = newPosition.x <= screenSize.x - halfMenuSize.x
                ? newPosition.x
                : screenSize.x - halfMenuSize.x;

            newPosition.x = newPosition.x >= halfMenuSize.x
                ? newPosition.x
                : halfMenuSize.x;
            
            newPosition.y = newPosition.y <= screenSize.y - halfMenuSize.y
                ? newPosition.y
                : screenSize.y - halfMenuSize.y;

            newPosition.y = newPosition.y >= halfMenuSize.y
                ? newPosition.y
                : halfMenuSize.y;

            _uiRadial.position = newPosition;
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
