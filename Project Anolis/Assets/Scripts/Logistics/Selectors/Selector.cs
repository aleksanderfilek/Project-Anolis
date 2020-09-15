using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Logistics
{
    public abstract class Selector : MonoBehaviour
    {
        private SelectorManager _selectorManager;
        protected Raycast Raycast;

        public void UpdateSelector()
        {
            if (!IsValidForSelection())
                return;
            Select();
        }

        protected abstract bool IsValidForSelection();
        protected abstract void Select();

        protected virtual void Awake()
        {
            _selectorManager = GetComponentInParent<SelectorManager>();
            _selectorManager.Selectors.Add(this);
            Raycast = GetComponentInParent<Raycast>();
        }
    }
}