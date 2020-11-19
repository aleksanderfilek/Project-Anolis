using System;
using System.Collections.Generic;
using Interaction;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActionActivator : MonoBehaviour
{
    private GameplayControls _controls;
    private InputActionMap _currentActionMap;
    
    [SerializeField] private List<string> alwaysEnabledActionMapNames;

    [Header("References for objects with callbacks")]
    [SerializeField] private CameraController cameraController;
    [SerializeField] private PlanetChooser planetChooser;
    [SerializeField] private Raycast raycast;

    private void Awake()
    {
        _controls = new GameplayControls();
    }

    private void Start()
    {
        ConnectActionsWithCallbacks();
        EnableAlwaysEnabledActionMaps();
    }


    public void SwitchCurrentActionMap(string actionMapName)
    {
        _currentActionMap?.Disable();
        EnableActionMapAsCurrent(actionMapName);
    }

    private void ConnectActionsWithCallbacks()
    {
        var interplanetaryMode = _controls.InterplanetaryMode;
        interplanetaryMode.Move.performed += cameraController.Interplanetary.UpdateMoveAmounts;
        interplanetaryMode.Move.canceled += cameraController.Interplanetary.UpdateMoveAmounts;
        interplanetaryMode.Zoom.performed += cameraController.Interplanetary.Zoom;
        interplanetaryMode.ChoosePlanet.performed += planetChooser.Choose;

        var planetaryMode = _controls.PlanetaryMode;
        planetaryMode.Rotate.performed += cameraController.Planetary.UpdateRotateAmounts;
        planetaryMode.Rotate.canceled += cameraController.Planetary.UpdateRotateAmounts;
        planetaryMode.Zoom.performed += cameraController.Planetary.Zoom;

        _controls.Gameplay.CastRay.performed += ctx => raycast.Shoot();
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
