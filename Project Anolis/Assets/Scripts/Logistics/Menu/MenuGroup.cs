using UnityEngine;

namespace Logistics
{
    public class MenuGroup : MonoBehaviour
    {
        [SerializeField] private Menu _defaultMenu;

        public Menu CurrentMenu { get; set; }

        public void Awake()
        {
            CurrentMenu = _defaultMenu;
            CurrentMenu.Show();
        }

        public void DeactivateCurrentMenu()
        {
            CurrentMenu.Hide();
            CurrentMenu = _defaultMenu;
        }
    }
}
