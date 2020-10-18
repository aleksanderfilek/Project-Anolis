using UnityEngine;

namespace Logistics
{
    public class MenuGroup : MonoBehaviour
    {
        public Showable _defaultMenu;

        public Showable CurrentMenu { get; set; }

        public void Awake()
        {
            ActivateMenu(_defaultMenu);
        }

        public void ActivateMenu(Showable menu)
        {
            CurrentMenu = menu;
            CurrentMenu.Show();
        }

        public void DeactivateCurrentMenu()
        {
            CurrentMenu.Hide();
            ActivateMenu(_defaultMenu);
        }
    }
}
