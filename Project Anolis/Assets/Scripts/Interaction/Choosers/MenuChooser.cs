using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace Interaction
{
    [RequireComponent(typeof(SelectorCollection))]
    public class MenuChooser : MonoBehaviour
    {
        [SerializeField] private Raycast raycast;
        [SerializeField] private List<Menu> menus;
        [SerializeField] private string chooseActionName;
        [SerializeField] private AnolisControlsActionActivator anolisControlsActionActivator;

        private SelectorCollection _selectorCollection;
        private MenuGroupWithChooser _menuGroup;

        public void Activate()
        {
            anolisControlsActionActivator.EnableAction(chooseActionName);
        }
        
        public void Deactivate()
        {
            anolisControlsActionActivator.DisableAction(chooseActionName);
        }
        
        private void Start()
        {
            _selectorCollection = GetComponent<SelectorCollection>();
            _menuGroup = GetComponentInParent<MenuGroupWithChooser>();
            #if UNITY_EDITOR
                if (_menuGroup == null)
                    Debug.LogError("Wrong structure. Chooser should be child of ShowableGroup that it manages.");
                if (!anolisControlsActionActivator.IsValidAction(chooseActionName))
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
                _menuGroup.ActivateMenu(menu);
                return;
            }
        }
    }
}