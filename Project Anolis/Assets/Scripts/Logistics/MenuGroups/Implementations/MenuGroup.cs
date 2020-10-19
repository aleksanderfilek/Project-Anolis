using UnityEngine;

namespace Logistics
{
    public class MenuGroup : ShowableGroup
    {
        [SerializeField] private Showable _openOnAwakeMenu;
        private Showable _currentMenu;

        private void Awake()
        {
            ActivateMenu(_openOnAwakeMenu);
        }

        public override void ActivateMenu(Showable menu)
        {
            _currentMenu = menu;
            _currentMenu.Show();
        }

        public override void DeactivateCurrent()
        {
            _currentMenu.Hide();
        }
    }
}
