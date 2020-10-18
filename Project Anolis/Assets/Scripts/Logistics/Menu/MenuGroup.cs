using UnityEngine;

namespace Logistics
{
    public class MenuGroup : MonoBehaviour
    {
        [SerializeField] private Menu _defaultMenu;

        public Menu CurrentMenu { get; set; }

        public void Awake()
        {
            ActivateMenu(_defaultMenu);
        }

        public void ActivateMenu(Menu menu)
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
