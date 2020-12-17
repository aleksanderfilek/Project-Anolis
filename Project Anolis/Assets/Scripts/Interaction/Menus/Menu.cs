using UnityEngine;

namespace Interaction
{
    /// <summary>
    /// This is logic for interaction between user and game. It determines when menu should be shown and what will happen after menu option is chosen. Each menu has reference to its ui, that is displayed when menu is shown.
    /// </summary>
    public abstract class Menu : MonoBehaviour
    {
        [SerializeField] protected GameObject ui;

        /// <summary>
        /// Activates menu's UI using setActive method.
        /// </summary>
        public virtual void Show()
        {
            ui.SetActive(true);
        }

        /// <summary>
        /// Deactivates menu's UI using setActive method.
        /// </summary>
        public virtual void Hide()
        {
            ui.SetActive(false);
        }
       
        /// <summary>
        /// This method can be used to determine if this menu should be shown based on current state of the game. It is used by <see cref="MenuChooser"/>
        /// </summary>
        /// <returns>This menu should be shown</returns>
        public abstract bool CanHandleSelection();
    }
}