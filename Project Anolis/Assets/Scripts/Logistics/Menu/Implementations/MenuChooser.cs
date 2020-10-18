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
            _raycast = GetComponentInParent<Raycast>();
            _selectorManager = GetComponentInParent<SelectorManager>();
            MenuManager = GetComponentInParent<MenuManager>();
            MenuManager.DefaultMenu = this;
            MenuManager.ActivateDefault();
        }

        public override bool CanHandleSelection()
        {
            return false;
        }

        public override void Show()
        {
            Debug.Log("Showing Menu Chooser");  //temporary, for testing
            base.Show();
        }

        public void Choose()
        {
            if (!_raycast.IsSomethingHit)
                return;
            _selectorManager.UpdateSelectors();
            foreach (var menu in MenuManager.Menus.Where(menu => menu.CanHandleSelection()))
            {
                menu.Show();
                Ui.SetActive(false);
                return;
            }
        }
    }
}