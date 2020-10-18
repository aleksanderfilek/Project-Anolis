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

        public virtual bool CanHandleSelection()
        {
            return false;
        }

        public virtual void Show()
        {
            Ui.SetActive(true);
        }

        public virtual void Hide()
        {
            Ui.SetActive(false);
        }

        public virtual void Deactivate()
        {
            Hide();
            MenuManager.ActivateDefault();
        }
    }
}