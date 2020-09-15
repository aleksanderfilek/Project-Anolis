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
        public abstract void UpdateSelector();

        protected virtual void Awake()
        {
            _selectorManager = GetComponentInParent<SelectorManager>();
            _selectorManager.Selectors.Add(this);
            Raycast = GetComponentInParent<Raycast>();
        }
    }
}