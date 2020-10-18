using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logistics.Editor
{
    public class BuildMenu : Menu
    {
        [SerializeField] private MenuGroup _menuGroup;

        public override void Show()
        {
            _menuGroup.CurrentMenu = this;
            base.Show();
        }
    }
}