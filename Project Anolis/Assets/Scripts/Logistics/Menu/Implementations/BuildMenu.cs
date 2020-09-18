using System.Collections.Generic;
using UnityEngine;

namespace Logistics
{
    public class BuildMenu : Menu
    {
        [SerializeField] private GameObject _ui;

        private TileSelector _tileSelector;

        protected override void Awake()
        {
            _tileSelector = GetComponentInChildren<TileSelector>();
            base.Awake();
        }

        public override void Show()
        {
            _ui.SetActive(true);
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
    }
}