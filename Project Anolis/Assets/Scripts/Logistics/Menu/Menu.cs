using UnityEngine;

namespace Logistics
{
    public abstract class Menu : MonoBehaviour
    {
        [SerializeField] protected GameObject Ui;

        protected MenuManager MenuManager;

        protected virtual void Awake()
        {
            MenuManager = GetComponentInParent<MenuManager>();
            MenuManager.Menus.Add(this);
        }

        public virtual void Show()
        {
            Ui.SetActive(true);
        }
        public abstract void OnClickOutsideMenu();
        public abstract bool IsValidForSelection();

        public virtual void Hide()
        {
            MenuManager.ClearMenu();
            MenuManager.CurrentMenu.Show(); //temporary, for testing
        }
    }
}