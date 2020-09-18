using System.Linq;
using UnityEngine;

namespace Logistics
{
    public class MenuChooser : Menu
    {
        private Raycast _raycast;
        private SelectorManager _selectorManager;

        protected override void Awake()
        {
            _selectorManager = GetComponentInParent<SelectorManager>();
            _raycast = GetComponentInParent<Raycast>();
            MenuManager = GetComponentInParent<MenuManager>();
            MenuManager.CurrentMenu = this;
        }

        public override void Show()
        {
            Debug.Log("Showing Menu Chooser");  //temporary, for testing
            base.Show();
        }

        public override void OnClickOutsideMenu()
        {
            if (!_raycast.IsSomethingHit)
                return;
            _selectorManager.UpdateSelectors();
            foreach (var menu in MenuManager.Menus.Where(menu => menu.IsValidForSelection()))
            {
                MenuManager.CurrentMenu = menu;
                MenuManager.CurrentMenu.Show();
                return;
            }
            Ui.SetActive(false);
        }

        public override bool IsValidForSelection()
        {
            return false;
        }
    }
}