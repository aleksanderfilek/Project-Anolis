using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Manages activation of actions and action maps. 
/// </summary>
/// <remarks>
/// This class does not store the actions it manages, nor does it connect them with callbacks. That functionality is provided in implementation of <see cref="ActionCallbackConnection"/>, which is needed by this class.
/// </remarks>
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

    /// <summary>
    /// Disables current action map (if any) and enables new action map
    /// </summary>
    /// <param name="newActionMapName">New action map to be activated</param>
    public void SwitchCurrentActionMapTo(string newActionMapName)
    {
        _currentActionMap?.Disable();
        EnableActionMapAsCurrent(newActionMapName);
    }

    /// <summary>
    /// Enables one action regardless of action map in which it is located.
    /// </summary>
    /// <param name="actionName">Name of action that will be enabled</param>
    public void EnableAction(string actionName)
    {
        controlsAsset[actionName].Enable();
    }

    /// <summary>
    /// Disables one action regardless of action map in which it is located. 
    /// </summary>
    /// <param name="actionName">Name of action that will be disabled</param>
    public void DisableAction(string actionName)
    {
        controlsAsset[actionName].Disable(); 
    }
    
    /// <summary>
    /// Checks if specified actions exists among actions that are managed by this class.
    /// </summary>
    /// <remarks>
    /// Should (probably) only be used for debugging.
    /// </remarks>
    /// <param name="actionName">Name of action that will be checked</param>
    /// <returns>True if action exists, false if action does not exist</returns>
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

