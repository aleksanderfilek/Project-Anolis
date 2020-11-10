﻿using System;
using System.Collections.Generic;
using Interaction;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActionActivator : MonoBehaviour
{
    private GameplayControls _controls;
    private InputActionMap _currentActionMap;
    
    [SerializeField] private string defaultActionMapName;
    [SerializeField] private List<string> alwaysEnabledActionMapNames;
    
    [Header("References for objects with callbacks")]
    [SerializeField] private InterplanetaryCameraController interplanetaryCameraController;
    [SerializeField] private PlanetaryCameraController planetaryCameraController;
    [SerializeField] private PlanetChooser planetChooser;
    [SerializeField] private Raycast raycast;
    
    private void Awake()
    {
        _controls = new GameplayControls();
        ConnectActionsWithCallbacks();
        EnableDefaultActionMap();
        EnableAlwaysEnabledActionMaps();
    }


    public void SwitchCurrentActionMap(string actionMapName)
    {
        _currentActionMap.Disable();
        EnableActionMapAsCurrent(actionMapName);
    }

    private void ConnectActionsWithCallbacks()
    {
        var interplanetaryMode = _controls.InterplanetaryMode;
        interplanetaryMode.Move.performed += interplanetaryCameraController.OnMove;
        interplanetaryMode.Move.canceled += interplanetaryCameraController.OnMove;
        interplanetaryMode.Zoom.performed += interplanetaryCameraController.OnZoom;
        interplanetaryMode.ChoosePlanet.performed += planetChooser.OnChoose;

        var planetaryMode = _controls.PlanetaryMode;
        planetaryMode.Rotate.performed += planetaryCameraController.OnRotate;
        planetaryMode.Rotate.canceled += planetaryCameraController.OnRotate;
        planetaryMode.Zoom.performed += planetaryCameraController.OnZoom;

        _controls.Gameplay.CastRay.performed += ctx => raycast.Shoot();
    }

    private void EnableDefaultActionMap()
    {
        EnableActionMapAsCurrent(defaultActionMapName);
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
