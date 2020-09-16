using System.Collections.Generic;
using UnityEngine;

namespace Logistics
{
    public class MenuManager : MonoBehaviour
    {
        public Menu CurrentMenu { get; set; }
        public List<Menu> Menus { get; set; } = new List<Menu>();

        public void ClearMenu()
        {
            CurrentMenu = GetComponentInChildren<MenuChooser>();
        }
    }
}