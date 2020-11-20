using System;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;

namespace Interaction
{
    [RequireComponent(typeof(SelectorCollection))]
    public class MenuChooser : MonoBehaviour
    {
        //todo remove invisible button and change clicking to action in input system
        
        [SerializeField] private Raycast raycast;
        [SerializeField] private List<Menu> menus;
        [SerializeField] private String chooseActionName;
        [SerializeField] private ActionActivator actionActivator;

        private SelectorCollection _selectorCollection;
        private ShowableGroupWithChooser _showableGroup;

        public void Activate()
        {
            actionActivator.EnableAction(chooseActionName);
        }
        
        public void Deactivate()
        {
            actionActivator.DisableAction(chooseActionName);
        }
        
        private void Start()
        {
            _selectorCollection = GetComponent<SelectorCollection>();
            _showableGroup = GetComponentInParent<ShowableGroupWithChooser>();
            #if UNITY_EDITOR
                if (_showableGroup == null)
                    Debug.LogError("Wrong structure. Chooser should be child of ShowableGroup that it manages.");
                if (!actionActivator.IsValidAction(chooseActionName))
                    Debug.LogError($"There is no action named '{chooseActionName}'", this);
            #endif
        }

        public void Choose()
        {
            if (!raycast.IsSomethingHit)
                return;
            _selectorCollection.UpdateSelectors();
            foreach (var menu in menus.Where(menu => menu.CanHandleSelection()))
            {
                _showableGroup.ActivateMenu(menu);
                return;
            }
        }
    }
}