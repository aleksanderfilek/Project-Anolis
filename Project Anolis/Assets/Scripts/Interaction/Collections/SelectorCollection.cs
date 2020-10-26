using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Interaction
{
    public class SelectorCollection : MonoBehaviour
    {
         public List<Selector> selectors;

        public void UpdateSelectors()
        {
            foreach (var selector in selectors)
            {
                selector.UpdateSelector();
            }
        }
    }
}