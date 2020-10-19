using System.Linq;
using UnityEngine;
using System.Collections.Generic;

namespace Logistics
{
    public class MenuChooser : Chooser
    {
        [SerializeField] private Raycast _raycast;
        [SerializeField] private SelectorManager _selectorManager;
        [SerializeField] private List<Menu> _menus;

        //TODO think about if one menu chooser could manage multiple menu groups, if not, it would be better to
        //acquire this reference in Awake from parent (which will always be menu group in this case)
        [SerializeField] private ShowableGroup _menuGroup;   

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