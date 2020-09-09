using UnityEngine;

namespace Logistics
{
    public abstract class Menu : MonoBehaviour
    {
        protected MenuManager MenuManager;
        protected Raycast Raycast;

        public abstract void Show();
        public abstract void ManageClick();

        public abstract bool CheckIfValidForSelection();

        private void Awake()
        {
            MenuManager = GetComponentInParent<MenuManager>();
            MenuManager.Menus.Add(this);
            Raycast = GetComponentInParent<Raycast>();
        }

        public virtual void Hide()
        {
            MenuManager.SetMenuChooser();
            MenuManager.CurrentMenu.Show(); //temporary, for testing
        }
    }
}