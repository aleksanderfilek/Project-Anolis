using System;
using System.Collections.Generic;
using Interaction;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnolisControlsActionActivator : MonoBehaviour
{
    private GameplayControls _controls;
    private InputActionMap _currentActionMap;
    
    [SerializeField] private List<string> alwaysEnabledActionMapNames;
    [SerializeField] private AnolisControlsActionCallbackConnection anolisControlsActionCallbackConnection;
    
    private void Awake()
    {
        _controls = new GameplayControls();
    }

    private void Start()
    {
        anolisControlsActionCallbackConnection.SetControls(_controls);
        anolisControlsActionCallbackConnection.Connect();
        EnableAlwaysEnabledActionMaps();
    }

    public void SwitchCurrentActionMap(string actionMapName)
    {
        _currentActionMap?.Disable();
        EnableActionMapAsCurrent(actionMapName);
    }

    public void EnableAction(string actionName)
    {
        _controls.asset[actionName].Enable();
    }

    public void DisableAction(string actionName)
    {
        _controls.asset[actionName].Disable(); 
    }

    public bool IsValidAction(string actionName)
    {
        try
        {
            _ = _controls.asset[actionName];
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
        var actionMap = _controls.asset.FindActionMap(actionMapName);
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

