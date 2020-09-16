using UnityEngine;

namespace Logistics
{
    public abstract class Menu : MonoBehaviour
    {
        protected MenuManager MenuManager;

        public abstract void Show();
        public abstract void ManageClick();

        public abstract bool CheckIfValidForSelection();

        protected virtual void Awake()
        {
            MenuManager = GetComponentInParent<MenuManager>();
            MenuManager.Menus.Add(this);
        }

        public virtual void Hide()
        {
            MenuManager.SetMenuChooser();
            MenuManager.CurrentMenu.Show(); //temporary, for testing
        }
    }
}