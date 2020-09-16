using System.Linq;
using UnityEngine;

namespace Logistics
{
    public class MenuChooser : Menu
    {
        private Raycast _raycast;
        private SelectorManager _selectorManager;
        private MenuManager _menuManager;

        protected override void Awake()
        {
            _selectorManager = GetComponentInParent<SelectorManager>();
            _raycast = GetComponentInParent<Raycast>();
            _menuManager = GetComponentInParent<MenuManager>();
            _menuManager.CurrentMenu = this;
        }

        public override void Show()
        {
            Debug.Log("Showing Menu Chooser");  //temporary, for testing
        }

        public override void ManageClick()
        {
            if (!_raycast.IsSomethingHit)
                return;
            _selectorManager.UpdateSelectors();
            foreach (var menu in _menuManager.Menus.Where(menu => menu.IsValidForSelection()))
            {
                _menuManager.CurrentMenu = menu;
                _menuManager.CurrentMenu.Show();
                return;
            }
        }

        public override bool IsValidForSelection()
        {
            return false;
        }
    }
}