using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public abstract class ShowableGroup : MonoBehaviour
    {
        public abstract void ActivateMenu(Showable showable);

        public abstract void DeactivateCurrent();
    }
}