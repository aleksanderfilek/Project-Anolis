using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Logistics
{
    public abstract class Menu
    {
        protected MenuSelector _menuSelector;
        protected TileSelector _tileSelector;

        public abstract void Show();
        public abstract void ManageClick();

        protected virtual void AddToMenus()
        {

        }

        protected virtual void CheckIfValidForSelection()
        {

        }
    }
}