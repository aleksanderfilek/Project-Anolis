using UnityEngine;

namespace Logistics
{
    public abstract class Menu : MonoBehaviour
    {
        protected MenuManager MenuManager;

        protected virtual void Awake()
        {
            MenuManager = GetComponentInParent<MenuManager>();
            MenuManager.Menus.Add(this);
        }

        public abstract void Show();
        public abstract void ManageClick();
        public abstract bool IsValidForSelection();

        public virtual void Hide()
        {
            MenuManager.ClearMenu();
            MenuManager.CurrentMenu.Show(); //temporary, for testing
        }
    }
}