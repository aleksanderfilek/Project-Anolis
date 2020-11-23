using System.Collections.Generic;
using Displayers;
using UnityEngine;
using UnityEngine.UI;

namespace Interaction.Editor
{
    public class BuildMenu : Menu
    {
        [SerializeField] private List<Placeable> placeables;
        [SerializeField] private GameObject buttonPrefab;
        [SerializeField] private TileSelector tileSelector;
        [SerializeField] private PlanetSelector planetSelector;
        [SerializeField] private Builder builder;
        [SerializeField] private Raycast raycaster;
        [SerializeField] private PlaceableDisplayer selectionDisplayer;
        
        public BuildingOption CurrentOption { get; private set; }

        public override bool CanHandleSelection()
        {
            return false;
        }

        public void Start()
        {
            if (placeables.Count == 0)
            {
                Debug.LogWarning(this + ": List of Placeables is empty");
            }
            CreateOptions();
        }

        public void SetSelectionTo(BuildingOption newOption)
        {
            CurrentOption = newOption;
            UpdateView();
        }
        
        public void UpdateView()
        {
            Placeable toDisplay = null;
            if (CurrentOption != null) toDisplay = CurrentOption.Placeable;
            selectionDisplayer.UpdateWith(toDisplay);
        }

        public void BuildSelected()
        {
            if (CurrentOption == null)
            {
                return;
            }
            raycaster.Shoot();
            tileSelector.UpdateSelector();
            planetSelector.UpdateSelector();
            if (tileSelector.SelectedTile == null)
            {
                Debug.LogError("Tile is not selected");
                return;
            }
            if (planetSelector.SelectedPlanet == null)
            {
                Debug.LogError("Planet is not selected");
                return;
            }
            builder.Build(CurrentOption.Placeable, tileSelector.SelectedTile, planetSelector.SelectedPlanet.transform);
        }

        private void CreateOptions()
        {
            foreach (var placeable in placeables)
            {
                var panelToAttach = ui.GetComponentInChildren<GridLayoutGroup>().transform;
                var newButton = Instantiate(buttonPrefab, panelToAttach);
                newButton.name = "Button - " + placeable.name;
                newButton.GetComponentInChildren<Text>().text = placeable.objectName;

                var containerModule = newButton.AddComponent<BuildingOption>();
                containerModule.Placeable = placeable;
                containerModule.AssignManager(this);

                newButton.GetComponent<Button>().onClick.AddListener(containerModule.OnSelection);
            }
        }
    }
}