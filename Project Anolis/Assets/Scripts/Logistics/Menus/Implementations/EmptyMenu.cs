using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logistics
{
    public class EmptyMenu : Menu
    {
        private void Awake()
        {
            ui = new List<GameObject>();
        }

        public override bool CanHandleSelection()
        {
            return false;
        }
    }
}