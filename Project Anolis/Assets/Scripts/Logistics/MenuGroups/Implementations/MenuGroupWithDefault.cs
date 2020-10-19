using UnityEngine;

namespace Logistics
{
    public class MenuGroupWithDefault : ShowableGroup
    {
        [SerializeField] private Showable _defaultMenu;
        private Showable _currentMenu;

        private void Awake()
        {
            ActivateMenu(_defaultMenu);
        }

        public override void ActivateMenu(Showable menu)
        {
            _currentMenu = menu;
            _currentMenu.Show();
        }

        public override void DeactivateCurrent()
        {
            _currentMenu.Hide();
            ActivateMenu(_defaultMenu);
        }
    }
}
