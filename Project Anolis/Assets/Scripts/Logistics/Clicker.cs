using UnityEngine;

namespace Logistics
{
    public class Clicker : MonoBehaviour
    {
        private Raycast _raycast;
        private MenuManager _menuManager;

        private void Awake()
        {
            _raycast = GetComponent<Raycast>();
            _menuManager = GetComponent<MenuManager>();
        }

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0))
                return;
            _raycast.Shoot();
            _menuManager.CurrentMenu.ManageClick();
        }
    }
}

