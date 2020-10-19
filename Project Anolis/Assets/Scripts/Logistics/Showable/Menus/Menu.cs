using UnityEngine;

namespace Logistics
{
    public abstract class Menu : Showable
    {
        public abstract bool CanHandleSelection();
    }
}