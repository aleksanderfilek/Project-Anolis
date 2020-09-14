using System.Collections.Generic;
using UnityEngine;

namespace Logistics
{
    public class MenuChooser : Menu
    {
        public override void Show()
        {
            Debug.Log("Showing Menu Chooser");  //temporary, for testing
        }

        public override void ManageClick()
        {
            Debug.Log("is hit: " + Raycast.IsSomethingHit);
            if (!Raycast.IsSomethingHit)
                return;
            foreach (var menu in MenuManager.Menus)
            {
                if(menu.CheckIfValidForSelection())
                {
                    MenuManager.CurrentMenu = menu;
                    MenuManager.CurrentMenu.Show();
                    return;
                }
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
            Raycast = GetComponentInParent<Raycast>();
        }
    }
}