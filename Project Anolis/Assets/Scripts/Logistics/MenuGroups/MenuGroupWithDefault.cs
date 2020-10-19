using UnityEngine;

namespace Logistics
{
    public class MenuGroupWithDefault : MonoBehaviour
    {
        [SerializeField] private Showable _defaultMenu;
        private Showable _currentMenu;

        public void Awake()
        {
            ActivateMenu(_defaultMenu);
        }

        public void ActivateMenu(Showable menu)
        {
            _currentMenu = menu;
            _currentMenu.Show();
        }

        public void ChangeCurrentToDefault()
        {
            _currentMenu.Hide();
            ActivateMenu(_defaultMenu);
        }
    }
}
