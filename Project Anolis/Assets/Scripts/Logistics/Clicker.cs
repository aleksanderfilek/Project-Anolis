using UnityEngine;

namespace Logistics
{
    public class Clicker : MonoBehaviour
    {
        private MenuManager _menuManager;
        private Raycast _raycast;

        private void Awake()
        {
            _menuManager = GetComponent<MenuManager>();
            _raycast = GetComponent<Raycast>();
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

