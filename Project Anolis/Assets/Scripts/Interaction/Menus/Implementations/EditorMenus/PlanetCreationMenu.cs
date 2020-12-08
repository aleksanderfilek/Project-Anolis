using UnityEngine;
using UnityEngine.UI;

namespace Interaction.Editor
{
    class PlanetCreationMenu : Menu
    {
        [SerializeField] private float maxGenerationOffset;
        [SerializeField] private Material defaultMaterial;
        [SerializeField] private PlanetMenu planetMenu;
        [SerializeField] private GameObject planetParent;

        private Text sizeIndicator;
        private Slider sizeChooser;
        private InputField nameChooser;
        
        private bool creationStarted;
        private GameObject createdPlanet;

        public void Start()
        {
            nameChooser = ui.transform.Find("Name Chooser")?.GetComponent<InputField>();
            sizeIndicator = ui.transform.Find("Size Indicator")?.GetComponent<Text>();
            sizeChooser = ui.transform.Find("Size Chooser")?.GetComponent<Slider>();
            ui.SetActive(false);
            Random.InitState((int)System.DateTime.Now.Ticks);
        }

        public void StartCreation()
        {
            creationStarted = true;
            ui.SetActive(true);
            createdPlanet = CreateNewPlanet(new Vector3(Random.value * maxGenerationOffset, 0 , Random.value * maxGenerationOffset), (int)sizeChooser.value );

            GameState.Get.CurrentFocus = createdPlanet;
            GameState.Get.ChangeModeToPlanetary();
            GameState.Get.ChangeModeToInterplanetary();
        }

        public void SubmitCreation()
        {
            var button = planetMenu.CreateButton();
            planetMenu.AssignPlanetToButton(createdPlanet, button);
            ResetInputValues();
        }
        
        public void CancelCreation()
        {
            Destroy(createdPlanet);
            GameState.Get.ChangeModeToInterplanetary();
            ResetInputValues();
        }

        public void UpdateSize()
        {
            sizeIndicator.text = ((int)sizeChooser.value).ToString();

            if (creationStarted)
            {
                Destroy(createdPlanet);
                createdPlanet = CreateNewPlanet(createdPlanet.transform.position, (int)sizeChooser.value);
            }
        }

        public void UpdatePlanetName()
        {
            if (creationStarted)
            {
                createdPlanet.name = nameChooser.text;
            }
        }

        private void ResetInputValues()
        {
            nameChooser.text = "New Planet";
            sizeChooser.SetValueWithoutNotify(1);
            sizeIndicator.text = ((int)sizeChooser.value).ToString();
        }

        private GameObject CreateNewPlanet(Vector3 pos, int size)
        {
            var planet = new GameObject(nameChooser.text);
            if (planetParent != null)
            {
                planet.transform.SetParent(planetParent.transform);
            }
            planet.transform.position = pos;
            planet.AddComponent<MeshFilter>();
            planet.AddComponent<MeshCollider>();
            var planetComp = planet.AddComponent<Planet>();
            planet.GetComponent<Renderer>().material = defaultMaterial;
            planetComp.RecreateWith(size);
            planet.tag = "Planet";

            return planet;
        }
        
        public override bool CanHandleSelection()
        {
            return false;
        }
    }
}
