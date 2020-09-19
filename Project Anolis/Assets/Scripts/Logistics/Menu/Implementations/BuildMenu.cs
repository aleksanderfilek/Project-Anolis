using System.Collections.Generic;
using UnityEngine;

namespace Logistics
{
    public class BuildMenu : Menu
    {
        [SerializeField] private List<Placeable> _buildingList;

        private RectTransform _uiRectTransform;
        private TileSelector _tileSelector;
        private PlanetSelector _planetSelector;
        private Builder _builder;

        protected override void Awake()
        {
            _uiRectTransform = Ui.GetComponent<RectTransform>();
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
            var halfMenuSize = _uiRectTransform.rect.size / 2;
            var screenWidth = Screen.width;
            var screenHeight = Screen.height;
            
            var newPosition = Input.mousePosition;

            newPosition.x = newPosition.x <= screenWidth - halfMenuSize.x
                ? newPosition.x
                : screenWidth - halfMenuSize.x;

            newPosition.x = newPosition.x >= halfMenuSize.x
                ? newPosition.x
                : halfMenuSize.x;
            
            newPosition.y = newPosition.y <= screenHeight - halfMenuSize.y
                ? newPosition.y
                : screenHeight - halfMenuSize.y;

            newPosition.y = newPosition.y >= halfMenuSize.y
                ? newPosition.y
                : halfMenuSize.y;

            _uiRectTransform.position = newPosition;

            base.Show();
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
