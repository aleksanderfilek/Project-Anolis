using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropertiesDisplayer : MonoBehaviour
{
    [SerializeField] private GameObject display;

    private Placeable currentSelection;
    private Dictionary<string,GameObject> displayElements;
    
    void Start()
    {
        displayElements = new Dictionary<string, GameObject>();
        BuildDisplay();
    }

    public void SetSelectionTo(Placeable p)
    {
        currentSelection = p;
        UpdateDisplay();
    }

    private void BuildDisplay()
    {
        var nameBox = new GameObject("Name");
        var descriptionBox = new GameObject("Description");

        // order of elements in displayElements matters!
        displayElements.Add("Name", nameBox);
        displayElements.Add("Description", descriptionBox);

        var font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        foreach (var elem in displayElements)
        {
            var box = elem.Value;
            box.transform.SetParent(display.transform);
            var text = box.AddComponent<Text>();
            text.font = font;
            text.alignment = TextAnchor.MiddleCenter;
            text.color = Color.black;
        }
    }
    
    private void UpdateDisplay()
    {
        displayElements["Description"].GetComponent<Text>().text = currentSelection.description;
        displayElements["Name"].GetComponent<Text>().text = currentSelection.objectName;
    }
}
