using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logistics
{
    public class BuildMenu : RadialMenu
    {


        public override void Show()
        {
            Debug.Log("Showing Build Menu");
        }

        public override void ManageClick()
        {
            Debug.Log("Managing Click in Build Menu");
        }
    }
}