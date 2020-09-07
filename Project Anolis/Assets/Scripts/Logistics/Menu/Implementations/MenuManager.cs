using System.Collections.Generic;
using UnityEngine;

namespace Logistics
{
    public class MenuManager : Menu
    {
        private Clicker _clicker;
        public override void Show()
        {
            Debug.Log("Showing Menu Manager");
        }

        public override void ManageClick()
        {
            Debug.Log("Managing Click in Menu Manager, so changing to Building Menu");
            foreach (var menu in MenuList.Menus)
            {
                if(menu.CheckIfValidForSelection())
                {
                    SetMenu(menu);
                    return;
                }
            }
        }

        public override bool CheckIfValidForSelection()
        {
            return false;
        }

        private void Awake()
        {
            _clicker = GetComponentInParent<Clicker>();
            SetMenu(this);
        }

        private void SetMenu(Menu menu)
        {
            _clicker.Menu = menu;
        }
    }
}