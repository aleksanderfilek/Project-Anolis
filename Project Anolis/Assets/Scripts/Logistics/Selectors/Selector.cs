using UnityEngine;

namespace Logistics
{
    public abstract class Selector : MonoBehaviour
    {
        private SelectorManager _selectorManager;
        protected Raycast Raycast;

        public void UpdateSelector()
        {
            if (IsValidForSelection())
                Select();
            else
                ClearSelection();
        }

        protected abstract bool IsValidForSelection();
        protected abstract void Select();
        protected abstract void ClearSelection();

        protected virtual void Awake()
        {
            _selectorManager = GetComponentInParent<SelectorManager>();
            _selectorManager.Selectors.Add(this);
            Raycast = GetComponentInParent<Raycast>();
        }
    }
}