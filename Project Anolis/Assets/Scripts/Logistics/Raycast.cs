using UnityEngine;

namespace Logistics
{
    public class Raycast : MonoBehaviour
    {
        [HideInInspector] public bool IsSomethingHit;
        public RaycastHit HitData;

        public void Shoot()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            IsSomethingHit = Physics.Raycast(ray, out HitData, 1000);
        }
    }
}