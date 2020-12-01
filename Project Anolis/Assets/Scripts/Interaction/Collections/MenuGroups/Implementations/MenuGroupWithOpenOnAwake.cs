using UnityEngine;

namespace Interaction
{
    public class MenuGroupWithOpenOnAwake : MenuGroup
    {
        [SerializeField] private Menu openOnAwakeMenu;
        private Menu _currentMenu;

        private void Start()
        {
            if (openOnAwakeMenu != null)
                ActivateMenu(openOnAwakeMenu);
        }

        public override void ActivateMenu(Menu menu)
        {
            _currentMenu = menu;
            _currentMenu.Show();
        }

        public override void DeactivateCurrent()
        {
            _currentMenu?.Hide();
        }
    }
}
