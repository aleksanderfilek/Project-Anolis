using UnityEngine;

namespace Interaction
{
    public abstract class Menu : Showable
    {
        public abstract bool CanHandleSelection();
    }
}