using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logistics
{
    public abstract class ShowableGroup : MonoBehaviour
    {

        public abstract void ActivateMenu(Showable menu);

        public abstract void DeactivateCurrent();
    }
}