using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class SettingsMenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] groups;
        private int _currentGroupIndex = 0;
        
        [Header("Graphics")]
        [SerializeField] private Dropdown resolutionDropdown;
        private Resolution[] _resolutions;

        private void Start()
        {
            #region GROUPS
            groups[0].SetActive(true);
            for (var i = 1; i < groups.Length; i++)
            {
                groups[i].SetActive(false);
            }
            #endregion
            
            #region RESOLUTION
            _resolutions = Screen.resolutions;

            resolutionDropdown.ClearOptions();
            var options = new List<string>();

            var currentResolutionIndex = 0;

            for(var i = _resolutions.Length - 1; i >= 0; i--)
            {
                string option = _resolutions[i].width+"x"+_resolutions[i].height;
                options.Add(option);

                if(_resolutions[i].width == Screen.currentResolution.width && _resolutions[i].height == Screen.currentResolution.height){
                    currentResolutionIndex = i;
                }
            }

            resolutionDropdown.AddOptions(options);
            resolutionDropdown.value = currentResolutionIndex;
            resolutionDropdown.RefreshShownValue();
            #endregion
        }

        public void ChangeGroup_Click(int index)
        {
            groups[_currentGroupIndex].SetActive(false);
            _currentGroupIndex = index;
            groups[_currentGroupIndex].SetActive(true);
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
        
        public void SetFullscreen(bool flag){
            Screen.fullScreen = flag;
        }

        public void SetResolution(int resolutionIndex){
            Resolution resolution = _resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }  
    }
}
