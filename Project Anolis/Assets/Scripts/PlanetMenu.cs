using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Interaction.Editor
{
    // This scripts a new button for each GameObject with "Planet" Tag.
    // Assigns buttons as a children of given panel
    public class PlanetMenu : Menu
    {
        [SerializeField] private GameObject buttonPrefab;
        private List<GameObject> planets;
    
        private void Start()
        {
            CheckSerializedFields();
            GetAllPlanets();
            foreach (var planet in planets)
            {
                AssignPlanetToButton(planet, CreateButton());
            }
        }
    
        // Adds a new button and assigns to it passed planet.
        // Does not check if this planet is already in list.
        public void AddPlanet(GameObject planet)
        {
            AssignPlanetToButton(planet, CreateButton());
        }
        
        public override bool CanHandleSelection()
        {
            return false;
        }
    
        private void GetAllPlanets()
        {
            var planetCandidates = GameObject.FindGameObjectsWithTag("Planet");
            var planetList = new List<GameObject>();
            foreach (var planet in planetCandidates)
            {
                if (planet.GetComponent<Planet>() is null)
                {
                    Debug.LogWarning(this + "One of object with tag: \"Planet\" does not have \"Planet\" component attached.");
                    continue;
                }
                planetList.Add(planet);
            }
    
            planets = planetList;
        }
    
        private GameObject CreateButton()
        {
            var button = Instantiate(buttonPrefab, ui.transform); 
            button.name = "Button Planet";
            return button;
        }
    
        private void AssignPlanetToButton(GameObject planet, GameObject button)
        {
            var planetButton = button.AddComponent<PlanetButton>();
            planetButton.Planet = planet;
            button.GetComponentInChildren<Text>().text = planet.name;
            button.GetComponent<Button>().onClick.AddListener(planetButton.ChangeFocusToThis);
        }
    
        private void CheckSerializedFields()
        {
            if (ui is null) 
                Debug.LogError(": Panel not assigned",this);
    
            if (buttonPrefab is null)
                Debug.LogError(": Button Prefab not assigned.", this);
        }
    }
}
