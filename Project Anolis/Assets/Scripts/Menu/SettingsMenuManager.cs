using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Menu
{
    public class SettingsMenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] groups;
        private int _currentGroupIndex = 0;

        private void Start()
        {
            groups[0].SetActive(true);
            for (int i = 1; i < groups.Length; i++)
            {
                groups[i].SetActive(false);
            }
        }

        public void ChangeGroup_Click(int index)
        {
            groups[_currentGroupIndex].SetActive(false);
            _currentGroupIndex = index;
            groups[_currentGroupIndex].SetActive(false);
        }
        
        public void Back_Click()
        {
            ChangeGroup_Click(0);
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
