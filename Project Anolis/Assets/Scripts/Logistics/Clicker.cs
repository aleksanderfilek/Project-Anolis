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
            Debug.Log("Menu List length: " + MenuList.Menus.Count);
            foreach (var menu in MenuList.Menus)
            {
                Debug.Log(menu);
            }
        }

    }
}

