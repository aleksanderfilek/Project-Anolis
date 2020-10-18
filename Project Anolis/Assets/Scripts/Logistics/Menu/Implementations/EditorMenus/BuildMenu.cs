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
        }

        public override bool CanHandleSelection()
        {
            return true;
        }
    }
}