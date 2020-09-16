using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Logistics
{
    public class MenuChooser : Menu
    {
        private Raycast _raycast;
        private SelectorManager _selectorManager;

        public override void Show()
        {
            Debug.Log("Showing Menu Chooser");  //temporary, for testing
        }

        public override void ManageClick()
        {
            if (!_raycast.IsSomethingHit)
                return;
            _selectorManager.UpdateSelectors();
            foreach (var menu in MenuManager.Menus.Where(menu => menu.CheckIfValidForSelection()))
            {
                MenuManager.CurrentMenu = menu;
                MenuManager.CurrentMenu.Show();
                return;
            }
        }

        public override bool CheckIfValidForSelection()
        {
            return false;
        }

        protected override void Awake()
        {
            MenuManager = GetComponentInParent<MenuManager>();
            MenuManager.CurrentMenu = this;
            _raycast = GetComponentInParent<Raycast>();
            _selectorManager = GetComponentInParent<SelectorManager>();
        }
    }
}