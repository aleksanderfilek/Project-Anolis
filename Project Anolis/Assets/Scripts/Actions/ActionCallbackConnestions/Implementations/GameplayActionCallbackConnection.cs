using System;
using Interaction;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameplayActionCallbackConnection : ActionCallbackConnection
{
    private GameplayControls _controls;
    
    [SerializeField] private CameraController cameraController;
    [SerializeField] private PlanetChooser planetChooser;
    [SerializeField] private MenuChooser planetaryMenuChooser;
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
        planetaryMode.ChooseMenu.performed += ctx => planetaryMenuChooser.Choose();

        _controls.Gameplay.CastRay.performed += ctx => raycast.Shoot(); 
    }
}