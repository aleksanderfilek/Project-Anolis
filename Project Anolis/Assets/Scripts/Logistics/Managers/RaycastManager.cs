using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Logistics
{
    public class RaycastManager : MonoBehaviour
    {
        [SerializeField] private Raycast raycast;

        private Mouse _mouse;
        
        private void Start()
        {
            _mouse = Mouse.current;
        }
        
        private void Update()
        {
            if (!_mouse.leftButton.wasPressedThisFrame)
                return;
            raycast.Shoot();
        }
    }
}

