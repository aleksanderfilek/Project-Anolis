using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logistics
{
    public class PlanetSelector : Selector
    {
        public GameObject SelectedPlanet;

        public override void UpdateSelector()
        {
            if (!isValidForSelection())
                return;
            SelectedPlanet = Raycast.HitData.transform.gameObject;
        }

        private bool isValidForSelection()
        {
            return Raycast.IsSomethingHit && Raycast.HitData.transform.CompareTag("Planet");
        }
    }
}