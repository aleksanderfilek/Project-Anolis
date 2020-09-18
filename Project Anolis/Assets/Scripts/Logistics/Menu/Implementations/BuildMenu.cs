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
            _builder = GetComponentInChildren<Builder>();
            _planetSelector = GetComponentInChildren<PlanetSelector>();
            base.Awake();
        }

        public override void Show()
        {
            Ui.SetActive(true);
        }

        public override void ManageClick()
        {
            Hide();
        }

        public override bool IsValidForSelection()
        {
            if (_tileSelector.SelectedTile == null)
                return false;
            return _tileSelector.SelectedTile.TileContent == null;
        }

        public void BuildKuznia()
        {
            _builder.Build(_buildingList[0], _tileSelector.SelectedTile, _planetSelector.SelectedPlanet.transform);
            Ui.SetActive(false);
        }

        public void BuildTratak()
        {
            _builder.Build(_buildingList[1], _tileSelector.SelectedTile, _planetSelector.SelectedPlanet.transform);
            Ui.SetActive(false);
        }
    }
}