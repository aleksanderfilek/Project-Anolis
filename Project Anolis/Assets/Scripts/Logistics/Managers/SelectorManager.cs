using System.Collections.Generic;
using UnityEngine;

namespace Logistics
{
    public class SelectorManager : MonoBehaviour
    {
        public List<Selector> Selectors = new List<Selector>();

        public void UpdateSelectors()
        {
            foreach (var selector in Selectors)
            {
                selector.UpdateSelector();
            }
        }
    }
}