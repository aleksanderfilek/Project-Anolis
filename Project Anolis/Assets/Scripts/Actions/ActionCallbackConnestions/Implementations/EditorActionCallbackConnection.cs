using System;
using CameraControl;
using Interaction;
using UnityEngine;
using UnityEngine.InputSystem;

public class EditorActionCallbackConnection : ActionCallbackConnection
{
    private EditorControls _controls;
    
    [SerializeField] private CameraController cameraController;
    [SerializeField] private FocusPlanetActionHandler focusPlanetActionHandler;
    [SerializeField] private Raycast raycast;

    private void Awake()
    {
        _controls = new EditorControls();
    }

    public override InputActionAsset GetInputActionAsset()
    {
        return _controls.asset;
    }

    public override void Connect()
    {
        var interplanetaryMode = _controls.InterplanetaryMode;
        interplanetaryMode.Move.performed += cameraController.Interplanetary.UpdateMoveAmounts;
        interplanetaryMode.Move.canceled += cameraController.Interplanetary.UpdateMoveAmounts;
        interplanetaryMode.Zoom.performed += cameraController.Interplanetary.Zoom;
        interplanetaryMode.FocusPlanet.performed += focusPlanetActionHandler.HandleFocusPlanet;

        var planetaryMode = _controls.PlanetaryMode;
        planetaryMode.Rotate.performed += cameraController.Planetary.UpdateRotateAmounts;
        planetaryMode.Rotate.canceled += cameraController.Planetary.UpdateRotateAmounts;
        planetaryMode.Zoom.performed += cameraController.Planetary.Zoom;

        _controls.Utilities.CastRay.performed += ctx => raycast.Shoot(); 
    }
}