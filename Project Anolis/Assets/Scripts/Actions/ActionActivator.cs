using System;
using System.Collections.Generic;
using Interaction;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(ActionCallbackConnection))]
public class ActionActivator : MonoBehaviour
{
    private InputActionAsset controlsAsset;
    private InputActionMap _currentActionMap;
    
    [SerializeField] private List<string> alwaysEnabledActionMapNames;
    [SerializeField] private ActionCallbackConnection actionCallbackConnection;

    private void Start()
    {
        controlsAsset = actionCallbackConnection.GetInputActionAsset();
        actionCallbackConnection.Connect();
        EnableAlwaysEnabledActionMaps();
    }

    public void SwitchCurrentActionMap(string actionMapName)
    {
        _currentActionMap?.Disable();
        EnableActionMapAsCurrent(actionMapName);
    }

    public void EnableAction(string actionName)
    {
        controlsAsset[actionName].Enable();
    }

    public void DisableAction(string actionName)
    {
        controlsAsset[actionName].Disable(); 
    }

    public bool IsValidAction(string actionName)
    {
        try
        {
            _ = controlsAsset[actionName];
        }
        catch (KeyNotFoundException)
        {
            return false;
        }
        return true;
    }
    
    private void EnableActionMapAsCurrent(string actionMapName)
    {
        _currentActionMap = EnableActionMap(actionMapName);
    }
    
    private InputActionMap EnableActionMap(string actionMapName)
    {
        var actionMap = controlsAsset.FindActionMap(actionMapName);
        if (actionMap == null)
            Debug.LogError($"Cannot find action map '{actionMapName}'.", this);

        actionMap.Enable();
        return actionMap;
    }
   
    private void EnableAlwaysEnabledActionMaps()
    {
        foreach (var mapName in alwaysEnabledActionMapNames)
        {
            EnableActionMap(mapName);
        }
    } 
}

