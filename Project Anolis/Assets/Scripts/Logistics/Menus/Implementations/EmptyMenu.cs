using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logistics
{
    public class EmptyMenu : Menu
    {
        private void Awake()
        {
            Ui = new GameObject();
        }

        public override bool CanHandleSelection()
        {
            return false;
        }
    }
}