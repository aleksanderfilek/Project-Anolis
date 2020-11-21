using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction.Editor
{
    public class BuildMenu : Menu
    {
        public override bool CanHandleSelection()
        {
            return false;
        }
    }
}