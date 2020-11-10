using System;
using System.Collections.Generic;
using UnityEditor;
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

    public void UpdateWith(BuildingOption p)
    {
        currentSelection = p != null ? p.Placeable : null;
        if (currentSelection == null)
        {
            foreach (var element in displayElements)
            {
                element.Value.SetActive(false);
            }
        }
        else
        {
            foreach (var element in displayElements)
            {
                element.Value.SetActive(true);
            }
            displayElements["Description"].GetComponent<Text>().text = currentSelection.description;
            displayElements["Name"].GetComponent<Text>().text = currentSelection.objectName;
        }
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
}
