using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Logistics
{
    public class SelectorManager : MonoBehaviour
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