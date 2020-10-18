using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logistics
{
    public class EmptyMenu : Menu
    {
        protected override void Awake()
        {
            Ui = new GameObject();
        }
    }
}