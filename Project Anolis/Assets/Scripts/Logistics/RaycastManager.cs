using UnityEngine;

namespace Logistics
{
    public class RaycastManager : MonoBehaviour
    {
        [SerializeField] private Raycast _raycast;

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0))
                return;
            _raycast.Shoot();
        }
    }
}

