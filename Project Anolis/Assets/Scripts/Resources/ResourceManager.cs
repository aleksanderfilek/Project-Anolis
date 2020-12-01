using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private static ResourceManager _instance;
    public static ResourceManager Get => _instance;


    [SerializeField] private static Resource[] _resource;
    
    private void Awake()
    {
        _instance = this;
    }

    static Resource GetRosourceByID(ushort ID)
    {
        if (_resource.Length == 0)
        {
            throw new ResourceNotExistException(ID);
        }
        
        var index = 0;
        while (ID != (ushort)_resource[index].resourceType)
        {
            index++;

            if (index >= _resource.Length)
            {
                throw new ResourceNotExistException(ID);
            }
        }

        return _resource[index];
    }
    
}
