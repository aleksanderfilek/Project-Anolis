using UnityEngine;

namespace Interaction
{
    public class ShowableGroupWithChooser : ShowableGroup
    {
        [SerializeField] private MenuChooser chooser;
        private Showable _currentMenu;

        public override void ActivateMenu(Showable showable)
        {
            _currentMenu = showable;
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
