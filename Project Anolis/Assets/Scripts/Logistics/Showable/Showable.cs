using UnityEngine;
using System.Collections.Generic;

namespace Logistics
{
    public abstract class Showable : MonoBehaviour
    {
        [SerializeField] protected List<GameObject> ui;

        public virtual void Show()
        {
            foreach (var uiElem in ui)
            {
                uiElem.SetActive(true);
            }
        }

        public virtual void Hide()
        {
            foreach (var uiElem in ui)
            {
                uiElem.SetActive(false);
            };
        }
    }
}