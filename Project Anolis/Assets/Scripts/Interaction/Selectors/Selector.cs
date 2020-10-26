using UnityEngine;

namespace Interaction
{
    public abstract class Selector : MonoBehaviour
    {
        [SerializeField] protected Raycast raycast;

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