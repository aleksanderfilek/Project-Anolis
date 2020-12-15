using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Interaction
{
    /// <summary>
    /// This is collection of selectors, it allows to update all selectors specified in list.
    /// </summary>
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