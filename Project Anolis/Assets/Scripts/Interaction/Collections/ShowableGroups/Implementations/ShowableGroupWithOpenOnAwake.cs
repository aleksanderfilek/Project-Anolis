using UnityEngine;

namespace Interaction
{
    public class ShowableGroupWithOpenOnAwake : ShowableGroup
    {
        [SerializeField] private Showable openOnAwakeShowable;
        private Showable _currentMenu;

        private void Awake()
        {
            ActivateMenu(openOnAwakeShowable);
        }

        public override void ActivateMenu(Showable showable)
        {
            _currentMenu = showable;
            _currentMenu.Show();
        }

        public override void DeactivateCurrent()
        {
            _currentMenu.Hide();
        }
    }
}
