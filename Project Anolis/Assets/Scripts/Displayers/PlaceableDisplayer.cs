using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Displayers
{
    public class PlaceableDisplayer : MonoBehaviour
    {
        [SerializeField] private GameObject display;

        private Placeable current;
        private Dictionary<string,GameObject> displayElements;
    
        private void Start()
        {
            displayElements = new Dictionary<string, GameObject>();
            display.SetActive(false);
            CreateLayout();
        }

        public void UpdateWith(Placeable newPlaceable)
        {
            current = newPlaceable;
            if (current == null)
            {
                display.SetActive(false);
                return;
            }
            display.SetActive(true);
            displayElements["Description"].GetComponent<Text>().text = current.description;
            displayElements["Name"].GetComponent<Text>().text = current.objectName;
        }

        private void CreateLayout()
        {
            var nameBox = new GameObject("Name");
            var descriptionBox = new GameObject("Description");
            var cancelButton = new GameObject("Cancel");
            
            
            displayElements.Add("Name", nameBox);
            displayElements.Add("Description", descriptionBox);

            var font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            foreach (var box in displayElements.Select(elem => elem.Value))
            {
                box.transform.SetParent(display.transform);
                var text = box.AddComponent<Text>();
                text.font = font;
                text.alignment = TextAnchor.MiddleCenter;
                text.color = Color.black;
            }
        }
    }
}
