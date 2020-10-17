using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logistics.Editor
{
    public class BuildMenu : Menu
    {
        public void OnHide()
        {
            Ui.SetActive(false);
            MenuManager.CurrentMenu = null;
        }

        public override bool CanHandleSelection()
        {
            return true;
        }
    }
}