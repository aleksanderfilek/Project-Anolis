using System.Collections.Generic;
using UnityEngine;

namespace Logistics
{
    public class MenuManager : MonoBehaviour
    {
        public Menu CurrentMenu { get; set; }
        public List<Menu> Menus { get; set; } = new List<Menu>();

        private MenuChooser _menuChooser;

        private void Awake()
        {
            _menuChooser = GetComponentInChildren<MenuChooser>();
        }

        public void ActivateMenu(Menu menu)
        {
            CurrentMenu = menu;
            CurrentMenu.Show();
        }

        public void ClearMenu()
        {
            ActivateMenu(_menuChooser);
        }
    }
}