using UnityEngine;

namespace Interaction
{
    /// <summary>
    /// Selectors use raycast result to get the reference of object hit. 
    /// </summary>
    /// <remarks>
    /// Selectors do not update raycast.
    /// </remarks>
    /// <seealso cref="Raycast"/>
    public abstract class Selector : MonoBehaviour
    {
        [SerializeField] protected Raycast raycast;

        /// <summary>
        /// If the raycast's hit result is an object that can be selected by this selector, its reference is saved in a corresponding selector property. Otherwise, that property is null.
        /// </summary>
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