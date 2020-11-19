using UnityEngine;

namespace Interaction
{
    public class ShowableGroupWithDefault : ShowableGroup
    {
        [SerializeField] private Showable defaultShowable;
        private Showable _currentMenu;

        private void Start()
        {
            ActivateMenu(defaultShowable);
        }

        public override void ActivateMenu(Showable showable)
        {
            _currentMenu = showable;
            _currentMenu.Show();
        }

        public override void DeactivateCurrent()
        {
            _currentMenu.Hide();
            ActivateMenu(defaultShowable);
        }
    }
}
