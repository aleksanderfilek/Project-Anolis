using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public abstract class MenuGroup : MonoBehaviour
    {
        public abstract void ActivateMenu(Menu menu);

        public abstract void DeactivateCurrent();
    }
}