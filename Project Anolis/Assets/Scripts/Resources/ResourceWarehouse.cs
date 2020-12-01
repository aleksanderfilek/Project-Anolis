using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceWarehouse : MonoBehaviour
{
    class ResourceElement
    {
        public ushort ID;
        public ushort amount;

        public ResourceElement(ushort _ID, ushort _amount)
        {
            ID = _ID;
            amount = _amount;
        }
    }
    
    private List<ResourceElement> _resourceElements;

    private void Start()
    {
        _resourceElements = new List<ResourceElement>();
    }

    public static void Add(object This, ushort ID, ushort amount)
    {
        var warehouse = ((MonoBehaviour) This).GetComponentInParent<ResourceWarehouse>();

        var index = FoundElement(warehouse, ID);
        if(index == -1)
        {
            warehouse._resourceElements.Add(new ResourceElement(ID, amount));
        }
        else
        {
            warehouse._resourceElements[index].amount += amount;
        }
    }

    public static void Remove(object This, ushort ID, ushort amount)
    {
        var warehouse = ((MonoBehaviour) This).GetComponentInParent<ResourceWarehouse>();
        
        var index = FoundElement(warehouse, ID);
        if(index == -1)
        {
            return;
        }
        
        warehouse._resourceElements.RemoveAt(index);
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