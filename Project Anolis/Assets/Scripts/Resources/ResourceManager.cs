using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    private static ResourceManager _instance;
    public static ResourceManager Get => _instance;


    [SerializeField] private Resource[] _resource;

    [SerializeField] private GameObject _resourcePanel;
    private List<ResourceElement> _resourceElements;
    
    
    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        ClearResourcesPanel();
        _resourcePanel.SetActive(false);
    }

    public static Resource GetRosourceByID(ushort ID)
    {
        if (_instance._resource.Length == 0)
        {
            throw new ResourceNotExistException(ID);
        }
        
        var index = 0;
        while (ID != (ushort)_instance._resource[index].resourceType)
        {
            index++;

            if (index >= _instance._resource.Length)
            {
                throw new ResourceNotExistException(ID);
            }
        }

        return _instance._resource[index];
    }

    public static void InitResourcesPanel(List<ResourceElement> resourceElements)
    {
        _instance._resourceElements = resourceElements;

        var n = resourceElements.Count;
        var childs = Utilities.Object.GetChilds(_instance._resourcePanel.transform);
        
        UpdateResourcesPanel();
        
        _instance._resourcePanel.SetActive(true);
    }

    public static void ClearResourcesPanel()
    {
        _instance._resourceElements = null;
        var childs = Utilities.Object.GetChilds(_instance._resourcePanel.transform);
        foreach (var c in childs)
        {
            c.gameObject.SetActive(false);
        }
        
        _instance._resourcePanel.SetActive(false);
    }

    public static void UpdateResourcesPanel()
    {
        var childs = Utilities.Object.GetChilds(_instance._resourcePanel.transform);

        //aktualizowanie tabeli surowców
        var n = _instance._resourceElements.Count;
        for (var i = 0; i < n && i < childs.Length; i++)
        {
            childs[i].GetChild(0).GetComponent<Image>().sprite = _instance._resource[_instance._resourceElements[i].ID].sprite;
            childs[i].GetChild(1).GetComponent<Text>().text = _instance._resourceElements[i].amount.ToString();
            childs[i].gameObject.SetActive(true);
        }
    }
}
