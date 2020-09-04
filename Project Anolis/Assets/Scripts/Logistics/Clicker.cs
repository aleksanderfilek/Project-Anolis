using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Logistics
{
    public class Clicker : MonoBehaviour
    {
        private Menu _menu;

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0))
                return;
            _menu.ManageClick();
        }

    }
}

