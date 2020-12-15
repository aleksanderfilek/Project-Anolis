using UnityEngine;

namespace Interaction
{
    //todo decument
    //todo think about if deactivate current should be public and not called in activate menu
    //todo think about if outsidemenubutton is needed
    public class MenuGroupWithChooser : MonoBehaviour
    {
        [SerializeField] private MenuChooser chooser;
        private Menu _currentMenu;

        public void ActivateMenu(Menu menu)
        {
            _currentMenu = menu;
            _currentMenu.Show();
            chooser.Deactivate();
        }

        public void DeactivateCurrent()
        {
            _currentMenu.Hide();
            chooser.Activate();
        }
    }
}
