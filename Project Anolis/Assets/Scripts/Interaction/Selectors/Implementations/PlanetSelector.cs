using UnityEngine;

namespace Interaction
{
    public class PlanetSelector : Selector
    {
        public GameObject SelectedPlanet { get; private set; }

        protected override bool IsValidForSelection()
        {
            return raycast.IsSomethingHit 
                   && (raycast.HitData.transform.CompareTag("Planet") 
                       || raycast.HitData.transform.CompareTag("Placeable"));
        }

        protected override void Select()
        {
            var hitData = raycast.HitData;
            if (hitData.transform.CompareTag("Planet"))
            {
                SelectedPlanet = hitData.transform.gameObject;
                return;
            }
            if (hitData.transform.CompareTag("Placeable"))
            {
                SelectedPlanet = hitData.collider.gameObject.GetComponentInParent<Planet>().gameObject;
                return;
            }
            Debug.LogError("Planet selection failed");
        }

        protected override void ClearSelection()
        {
            SelectedPlanet = null;
        }
    }
}