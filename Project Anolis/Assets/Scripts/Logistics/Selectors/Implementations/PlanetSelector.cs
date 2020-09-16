using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logistics
{
    public class PlanetSelector : Selector
    {
        public GameObject SelectedPlanet { get; private set; }

        protected override bool IsValidForSelection()
        {
            return Raycast.IsSomethingHit && Raycast.HitData.transform.CompareTag("Planet");
        }

        protected override void Select()
        {
            SelectedPlanet = Raycast.HitData.transform.gameObject;
        }

        protected override void ClearSelection()
        {
            SelectedPlanet = null;
        }
    }
}