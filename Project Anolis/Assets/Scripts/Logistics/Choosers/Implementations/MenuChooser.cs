using System.Linq;
using UnityEngine;
using System.Collections.Generic;

namespace Logistics
{
    public class MenuChooser : Chooser
    {
        private Raycast _raycast;
        private SelectorManager _selectorManager;
        [SerializeField] private List<Menu> _menus;
        [SerializeField] private MenuGroup _menuGroup;

        protected void Awake()
        {
            _raycast = GetComponentInParent<Raycast>();
            _selectorManager = GetComponentInParent<SelectorManager>();
        }

        public void Choose()
        {
            if (!_raycast.IsSomethingHit)
                return;
            _selectorManager.UpdateSelectors();
            foreach (var menu in _menus.Where(menu => menu.CanHandleSelection()))
            {
                _menuGroup.ActivateMenu(menu);
                Hide();
                return;
            }
        }
    }
}