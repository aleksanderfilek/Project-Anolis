using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Interaction
{
    public abstract class UnderMouseMenu : Menu
    {
        private RectTransform _uiRectTransform;

        private void Awake()
        {
            _uiRectTransform = Ui.GetComponent<RectTransform>();
        }

        public override void Show()
        {
            var halfMenuSize = _uiRectTransform.rect.size / 2;
            var screenWidth = Screen.width;
            var screenHeight = Screen.height;
            
            var newPosition = Mouse.current.position.ReadValue();

            newPosition.x = newPosition.x <= screenWidth - halfMenuSize.x
                ? newPosition.x
                : screenWidth - halfMenuSize.x;

            newPosition.x = newPosition.x >= halfMenuSize.x
                ? newPosition.x
                : halfMenuSize.x;
            
            newPosition.y = newPosition.y <= screenHeight - halfMenuSize.y
                ? newPosition.y
                : screenHeight - halfMenuSize.y;

            newPosition.y = newPosition.y >= halfMenuSize.y
                ? newPosition.y
                : halfMenuSize.y;

            _uiRectTransform.position = newPosition;

            base.Show();
        }
    }
}