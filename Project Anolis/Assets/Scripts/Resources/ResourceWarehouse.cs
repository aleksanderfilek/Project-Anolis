using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceWarehouse : MonoBehaviour
{

    public List<ResourceElement> _resourceElements;

    private void Start()
    {
        _resourceElements = new List<ResourceElement>();
    }

    public static void UpdateResources(object sender, ushort ID, short amount)
    {
        var warehouse = ((GameObject) sender).GetComponent<ResourceWarehouse>();

        int index = FoundElement(warehouse, ID);

        if (index == -1) // dodaj surowiec
        {
            var newElement = new ResourceElement(ID, amount);
            warehouse._resourceElements.Add(newElement);
        }
        else // aktualizuj surowiec
        {
            warehouse._resourceElements[index].amount += amount;
            if (warehouse._resourceElements[index].amount <= 0)
            {
                warehouse._resourceElements.RemoveAt(index);
            }
        }
        
        ResourceManager.UpdateResourcesPanel();
    }

    private static int FoundElement(ResourceWarehouse warehouse, ushort ID)
    {
        var elements = warehouse._resourceElements;
        for (ushort i = 0; i < elements.Count; i++)
        {
            if (elements[i].ID == ID)
            {
                return i;
            }
        }
        return -1;
    }
}