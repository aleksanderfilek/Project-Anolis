using UnityEngine;

namespace Interaction
{
    public abstract class Menu : MonoBehaviour
    {
        [SerializeField] protected GameObject ui;

        public virtual void Show()
        {
            ui.SetActive(true);
        }

        public virtual void Hide()
        {
            ui.SetActive(false);
        }
        
        public abstract bool CanHandleSelection();
    }
}