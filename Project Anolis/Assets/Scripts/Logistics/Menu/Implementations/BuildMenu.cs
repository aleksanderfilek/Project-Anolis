using System.Collections.Generic;
using UnityEngine;

namespace Logistics
{
    public class BuildMenu : Menu
    {
        [SerializeField] private List<Placeable> _buildingList;

        private Builder _builder;
        private TileSelector _tileSelector;
        private PlanetSelector _planetSelector;
        private Canvas _uiCanvas;
        private RectTransform _uiRadial;

        protected override void Awake()
        {
            _builder = GetComponentInChildren<Builder>();
            _tileSelector = GetComponentInChildren<TileSelector>();
            _planetSelector = GetComponentInChildren<PlanetSelector>();
            _uiCanvas = GetComponentInChildren<Canvas>();
            base.Awake();
        }

        public override void Show()
        {
            _uiCanvas.enabled = true;
            _uiRadial.anchoredPosition = new Vector2(-20, -20);
        }

        public override void ManageClick()
        {
            Hide();
        }

        public void Build1()
        {
            _builder.Build(_buildingList[0], _tileSelector.SelectedTile, _planetSelector.SelectedPlanet.transform);
            _uiCanvas.enabled = false;
        }

        public void Build2()
        {
            _builder.Build(_buildingList[1], _tileSelector.SelectedTile, _planetSelector.SelectedPlanet.transform);
            _uiCanvas.enabled = false;
        }

        public override bool IsValidForSelection()
        {
            if (_tileSelector.SelectedTile == null)
                return false;
            return _tileSelector.SelectedTile.TileContent == null;
        }
    }
}