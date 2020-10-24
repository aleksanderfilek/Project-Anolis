using UnityEngine;

namespace Logistics
{
    public abstract class Selector : MonoBehaviour
    {
        [SerializeField] protected Raycast Raycast;

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
    }
}