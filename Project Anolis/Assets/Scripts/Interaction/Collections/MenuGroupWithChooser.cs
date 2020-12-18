using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Interaction
{
    /// <summary>
    /// Manages menu activation so that only one menu is active at a time. Also has method to choose menu from its childs that should be opened after choose action has occured.
    /// </summary>
    public class MenuGroupWithChooser : MonoBehaviour
    {
        [SerializeField] private Raycast raycast;
        [SerializeField] private ActionActivator actionActivator;
        [SerializeField] [Tooltip("Name of action from actionActivator that is responsible for showing appropriate menu")]
        private string chooseActionName;
        [SerializeField] private List<Selector> selectors;
       
        private Menu[] _menuList;
        private Menu _currentMenu;
        
        private void Start()
        {
            _menuList = GetComponentsInChildren<Menu>(); 
            #if UNITY_EDITOR
                if (!actionActivator.IsValidAction(chooseActionName))
                    Debug.LogError($"There is no action named '{chooseActionName}'", this);
                if (selectors.Count <= 0 || selectors.All(selector => selector == null))
                    Debug.LogWarning("There are not any selectors in selector list", this);
                if (_menuList.Length <= 0)
                    Debug.LogError("This menu group has no childs. It should have childeren, so that it can choose appropriate menu from among them after menu chose action has occured.", this);
            #endif
        }
       
        /// <summary>
        /// Callback for choose action. Iterates through menu list until it finds menu that should be shown.
        /// </summary>
        public void ShowAppropriateMenu()
        {
            if (!raycast.IsSomethingHit)
                return;
            foreach (var selector in selectors)
            {
                selector.UpdateSelector();
            }
            foreach (var menu in _menuList.Where(menu => menu.CanHandleSelection()))
            {
                ActivateMenu(menu);
                return;
            }
        }
        
        /// <summary>
        /// Callback, hides current menu and enables choose action.
        /// </summary>
        public void DeactivateCurrent()
        {
            _currentMenu.Hide();
            ActivateAction();
        }
       
        private void ActivateMenu(Menu menu)
        {
            _currentMenu = menu;
            _currentMenu.Show();
            DeactivateAction();
        }
        
        private void ActivateAction()
        {
            actionActivator.EnableAction(chooseActionName);
        }

        private void DeactivateAction()
        {
            actionActivator.DisableAction(chooseActionName);
        }
    }
}
