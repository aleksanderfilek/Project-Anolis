using UnityEngine;

namespace Logistics
{
    public class MenuGroup : MonoBehaviour
    {
        [SerializeField] private Showable _openOnAwakeMenu;
        private Showable _currentMenu;

        private void Awake()
        {
            ActivateMenu(_openOnAwakeMenu);
        }

        public void ActivateMenu(Showable menu)
        {
            _currentMenu = menu;
            _currentMenu.Show();
        }

        public void DeactivateCurrent()
        {
            _currentMenu.Hide();
        }
    }
}
