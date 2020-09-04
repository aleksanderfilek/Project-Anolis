using System.Collections.Generic;
using UnityEngine;

namespace Logistics
{
    public class MenuManager : Menu
    {
        private Clicker _clicker;

        private void Awake()
        {
            _clicker = GetComponentInParent<Clicker>();
            SetMenu(this);
        }


        public override void Show()
        {
            Debug.Log("Showing Menu Manager");
        }

        public override void ManageClick()
        {
            Debug.Log("Managing Click in Menu Manager, so changing to Building Menu");
            SetMenu(MenuList.Menus[0]);
        }

        private void SetMenu(Menu menu)
        {
            _clicker.Menu = menu;
        }
    }
}