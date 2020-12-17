using System.Linq;
using UnityEngine;
using System.Collections.Generic;

namespace Interaction
{
    /// <summary>
    /// This class is responsible for showing appropriate menu after choose action was performed using menus' <see cref="Menu.CanHandleSelection"/>
    /// </summary>
    [RequireComponent(typeof(SelectorCollection))]
    public class MenuChooser : MonoBehaviour
    {
        [SerializeField] private Raycast raycast;
        [SerializeField] private List<Menu> menus;
        [SerializeField] private string chooseActionName;
        [SerializeField] private ActionActivator actionActivator;

        private SelectorCollection _selectorCollection;
        private MenuGroupWithChooser _menuGroup;

        private void Start()
        {
            _selectorCollection = GetComponent<SelectorCollection>();
            _menuGroup = GetComponentInParent<MenuGroupWithChooser>();
            #if UNITY_EDITOR
                if (_menuGroup == null)
                    Debug.LogError("Wrong structure. Chooser should be child of ShowableGroup that it manages.");
                if (!actionActivator.IsValidAction(chooseActionName))
                    Debug.LogError($"There is no action named '{chooseActionName}'", this);
            #endif
        }
        
        /// <summary>
        /// Activates choose action specified in inspector.
        /// </summary>
        public void Activate()
        {
            actionActivator.EnableAction(chooseActionName);
        }
        
        /// <summary>
        /// Deactivates choose action specified in the inspector, therefore disabling menu choosing.
        /// </summary>
        public void Deactivate()
        {
            actionActivator.DisableAction(chooseActionName);
        }
        
        /// <summary>
        /// Iterates through menu list until it finds menu that should be shown.
        /// </summary>
        public void Choose()
        {
            if (!raycast.IsSomethingHit)
                return;
            _selectorCollection.UpdateSelectors();
            foreach (var menu in menus.Where(menu => menu.CanHandleSelection()))
            {
                _menuGroup.ActivateMenu(menu);
                return;
            }
        }
    }
}