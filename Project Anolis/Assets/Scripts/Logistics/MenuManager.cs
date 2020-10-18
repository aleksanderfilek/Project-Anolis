using System.Collections.Generic;
using UnityEngine;

namespace Logistics
{
    public class MenuManager : MonoBehaviour
    {
        public Menu DefaultMenu { get; set; } = null;
        public List<Menu> Menus { get; set; } = new List<Menu>();

        public void ActivateDefault()
        {
            DefaultMenu.Show();
        }
    }
}