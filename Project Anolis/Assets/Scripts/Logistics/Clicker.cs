using UnityEngine;

namespace Logistics
{
    public class Clicker : MonoBehaviour
    {
        public Menu Menu;

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0))
                return;
            Menu.ManageClick();
        }
    }
}

