using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menu
{
    public class MainMenuManager : MonoBehaviour
    {
        public static MainMenuManager Get { get; private set; }

        [SerializeField] private GameObject[] canvasElements;
        private int _currentCanvasElementIndex = 0;

        private void Awake()
        {
            Get = this;
        }

        private void Start()
        {
            canvasElements[0].SetActive(true);
            for (var i = 1; i < canvasElements.Length; i++)
            {
                canvasElements[i].SetActive(false);
            }
        }

        public void ChangeCanvasElement_Click(int index)
        {
            canvasElements[_currentCanvasElementIndex].SetActive(false);
            _currentCanvasElementIndex = index;
            canvasElements[_currentCanvasElementIndex].SetActive(true);
        }

        public void Quit_Click()
        {
            Application.Quit();
        }
    }    
}

