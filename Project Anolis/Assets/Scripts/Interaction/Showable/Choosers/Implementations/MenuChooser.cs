using System;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;

namespace Interaction
{
    [RequireComponent(typeof(SelectorCollection))]
    public class MenuChooser : Chooser
    {
        //todo remove invisible button and change clicking to action in input system
        
        [SerializeField] private Raycast raycast;
        [SerializeField] private List<Menu> menus;

        private SelectorCollection _selectorCollection;
        private ShowableGroup _showableGroup;
        
        private void Awake()
        {
            _selectorCollection = GetComponent<SelectorCollection>();
            _showableGroup = GetComponentInParent<ShowableGroup>();
            if (_showableGroup == null)    // TODO remove when building
                Debug.LogError("Wrong structure. Chooser should be child of ShowableGroup that it manages.");
        }

        public void Choose()
        {
            if (!raycast.IsSomethingHit)
                return;
            _selectorCollection.UpdateSelectors();
            foreach (var menu in menus.Where(menu => menu.CanHandleSelection()))
            {
                _showableGroup.ActivateMenu(menu);
                Hide();
                return;
            }
        }
    }
}