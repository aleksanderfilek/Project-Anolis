using UnityEngine;

namespace Logistics
{
    public abstract class Menu : MonoBehaviour
    {
        public abstract void Show();
        public abstract void ManageClick();

        public abstract bool CheckIfValidForSelection();

        private void Awake(){
            MenuList.Menus.Add(this);
        }
    }
}