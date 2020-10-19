using UnityEngine;

namespace Logistics
{
    public class Raycast : MonoBehaviour
    {
        public bool IsSomethingHit { get; private set; }
        public RaycastHit HitData;
        public void Shoot()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            IsSomethingHit = Physics.Raycast(ray, out HitData, 1000);
        }
    }
}