using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace Interaction.Editor
{
    public class BuildMenu : Menu
    {
        [SerializeField] private List<Placeable> _placeables;
        [SerializeField] private GameObject _buttonPrefab;
        [SerializeField] private TileSelector _tileSelector;
        [SerializeField] private PlanetSelector _planetSelector;
        [SerializeField] private Builder _builder;
        [SerializeField] private Raycast _raycaster;
        
        public Placeable CurrentSelection { get; set; }

        public override bool CanHandleSelection()
        {
            return false;
        }

        public void Start()
        {
            if (_placeables.Count == 0)
            {
                Debug.LogWarning(this + ": List of Placeables is empty");
                return;
            }

            foreach (var placeable in _placeables)
            {
                var panelToAttach = ui.GetComponentInChildren<GridLayoutGroup>().transform;
                var newButton = Instantiate(_buttonPrefab, panelToAttach);
                newButton.name = "Button - " + placeable.name;
                newButton.GetComponentInChildren<Text>().text = placeable.objectName;
                newButton.AddComponent<OptionContainer>().option = placeable;
                var containerModule = newButton.GetComponentInChildren<OptionContainer>();
                containerModule.AssignManager(this);
                newButton.GetComponentInChildren<Button>().onClick.AddListener(containerModule.OnSelection);
            }
        }

        public void BulidSelected()
        {
            if (CurrentSelection == null) return;
            _raycaster.Shoot();
            _tileSelector.UpdateSelector();
            _planetSelector.UpdateSelector();
            if (_tileSelector.SelectedTile == null)
            {
                Debug.LogError("Tile is not selected");
                if (_planetSelector.SelectedPlanet == null)
                {
                    Debug.LogError("Planet is not selected");
                }
            }
            else _builder.Build(CurrentSelection, _tileSelector.SelectedTile, _planetSelector.SelectedPlanet.transform);
        }
    }
}