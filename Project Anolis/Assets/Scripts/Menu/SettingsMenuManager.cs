using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menu
{
    public class SettingsMenuManager : MonoBehaviour
    {
        public void Back_Click()
        {
            MainMenuManager.Get.ChangeCanvasElement_Click(0);
        }

        public void Restart_Click()
        {
            
        }

        public void Save_Click()
        {
            
        }
    }
}
