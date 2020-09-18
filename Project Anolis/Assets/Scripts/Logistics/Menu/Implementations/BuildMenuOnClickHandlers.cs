using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logistics
{
    public class BuildMenuOnClickHandlers : MonoBehaviour
    {
        [SerializeField] private List<Placeable> _buildingList;
        [SerializeField] private GameObject _ui;

        private Builder _builder;
        private PlanetSelector _planetSelector;
        private TileSelector _tileSelector;

        private void Awake()
        {
            _builder = GetComponentInChildren<Builder>();
            _planetSelector = GetComponentInChildren<PlanetSelector>();
            _tileSelector = GetComponentInChildren<TileSelector>();
        }

        public void BuildKuznia()
        {
            _builder.Build(_buildingList[0], _tileSelector.SelectedTile, _planetSelector.SelectedPlanet.transform);
            _ui.SetActive(false);
        }

        public void BuildTratak()
        {
            _builder.Build(_buildingList[1], _tileSelector.SelectedTile, _planetSelector.SelectedPlanet.transform);
            _ui.SetActive(false);
        }
    }
}