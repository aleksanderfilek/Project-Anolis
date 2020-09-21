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

        public abstract bool CanHandleSelection();

        public virtual void Show()
        {
            Ui.SetActive(true);
        }

        public virtual void Hide()
        {
            Ui.SetActive(false);
            MenuManager.ClearMenu();
        }
    }
}