using UnityEngine;

namespace Logistics
{
    public abstract class Menu : MonoBehaviour
    {

        public abstract void Show();
        public abstract void ManageClick();

        private void Awake(){
            AddToMenus();
        }

        protected virtual void AddToMenus()
        {
            MenuList.Menus.Add(this);
        }

        protected virtual void CheckIfValidForSelection()
        {

        }
    }
}