using UnityEngine;

namespace Interaction
{
    public class MenuGroupWithChooser : MenuGroup
    {
        [SerializeField] private MenuChooser chooser;
        private Menu _currentMenu;

        public override void ActivateMenu(Menu menu)
        {
            _currentMenu = menu;
            _currentMenu.Show();
            chooser.Deactivate();
        }

        public override void DeactivateCurrent()
        {
            _currentMenu.Hide();
            chooser.Activate();
        }
    }
}
