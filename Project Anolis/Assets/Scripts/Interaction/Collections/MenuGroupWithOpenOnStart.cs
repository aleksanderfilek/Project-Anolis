using UnityEngine;

namespace Interaction
{
    /// <summary>
    /// Manages menu activation so that only one menu is active at a time. Menu that is activated after the initialisation can be set.
    /// </summary>
    public class MenuGroupWithOpenOnStart : MonoBehaviour
    {
        [SerializeField] private Menu openOnStartMenu;
        private Menu _currentMenu;

        private void Start()
        {
            if (openOnStartMenu != null)
                ChangeCurrentMenuTo(openOnStartMenu);
        }

        /// <summary>
        /// Deactivates current menu, and activates new menu.
        /// </summary>
        /// <param name="newMenu">Menu that will be activated</param>
        public void ChangeCurrentMenuTo(Menu newMenu)
        {
            DeactivateCurrent();
            _currentMenu = newMenu;
            _currentMenu.Show();
        }

        private void DeactivateCurrent()
        {
            _currentMenu?.Hide();
        }
    }
}
