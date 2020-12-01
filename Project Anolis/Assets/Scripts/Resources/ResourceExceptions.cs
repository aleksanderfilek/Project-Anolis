using System;
using UnityEngine;

public class ResourceNotExistException:Exception
    {
        public ResourceNotExistException(ushort ID)
        {
            Debug.Log("Resource with ID: "+ ID +" not exist");
        }
    }
