using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

namespace Logistics.Editor
{
    public class BuildMenu : Menu
    {
        [SerializeField] private List<Placeable> _placeables;
        [SerializeField] private GameObject _buttonPrefab;

        public override bool CanHandleSelection()
        {
            return false;
        }

        public void Start()
        {
            if (_placeables.Count == 0)
            {
                Debug.Log(this + ": List of placeables is empty");
                return;
            }

            foreach (var placeable in _placeables)
            {
                var newButton = Instantiate(_buttonPrefab, Ui.transform);
                newButton.GetComponentInChildren<Text>().text = placeable.objectName;
            }
        }
    }
}