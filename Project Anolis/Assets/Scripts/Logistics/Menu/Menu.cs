using UnityEngine;

namespace Logistics
{
    public abstract class Menu : MonoBehaviour
    {
        private MenuManager _menuManager;

        protected virtual void Awake()
        {
            _menuManager = GetComponentInParent<MenuManager>();
            _menuManager.Menus.Add(this);
        }

        public abstract void Show();
        public abstract void ManageClick();
        public abstract bool IsValidForSelection();

        public virtual void Hide()
        {
            _menuManager.ClearMenu();
            _menuManager.CurrentMenu.Show(); //temporary, for testing
        }
    }
}