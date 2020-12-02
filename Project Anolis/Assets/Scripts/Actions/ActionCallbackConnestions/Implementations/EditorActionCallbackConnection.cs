using System;
using Interaction;
using UnityEngine;
using UnityEngine.InputSystem;

public class EditorActionCallbackConnection : ActionCallbackConnection
{
    private GameplayControls _controls;    //todo add another controls (EditorControls) or change name to AnolisControls
    
    [SerializeField] private CameraController cameraController;
    [SerializeField] private PlanetChooser planetChooser;
    [SerializeField] private Raycast raycast;

    private void Awake()
    {
        _controls = new GameplayControls();
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
        interplanetaryMode.ChoosePlanet.performed += planetChooser.Choose;

        var planetaryMode = _controls.PlanetaryMode;
        planetaryMode.Rotate.performed += cameraController.Planetary.UpdateRotateAmounts;
        planetaryMode.Rotate.canceled += cameraController.Planetary.UpdateRotateAmounts;
        planetaryMode.Zoom.performed += cameraController.Planetary.Zoom;

        _controls.Gameplay.CastRay.performed += ctx => raycast.Shoot(); 
    }
}