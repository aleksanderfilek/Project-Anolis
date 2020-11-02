using UnityEngine;

namespace Interaction
{
    public class PlanetSelector : Selector
    {
        public GameObject SelectedPlanet { get; private set; }

        protected override bool IsValidForSelection()
        {
            return raycast.IsSomethingHit && raycast.HitData.transform.CompareTag("Planet");
        }

        protected override void Select()
        {
            SelectedPlanet = raycast.HitData.transform.gameObject;
        }

        protected override void ClearSelection()
        {
            SelectedPlanet = null;
        }
    }
}