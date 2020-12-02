using Interaction;
using UnityEngine;

public class GameplayActionCallbackConnection : AnolisControlsActionCallbackConnection
{
    [SerializeField] private CameraController cameraController;
    [SerializeField] private PlanetChooser planetChooser;
    [SerializeField] private MenuChooser planetaryMenuChooser;
    [SerializeField] private Raycast raycast;

    protected override void ConnectActionsWithCallbacks()
    {
        var interplanetaryMode = Controls.InterplanetaryMode;
        interplanetaryMode.Move.performed += cameraController.Interplanetary.UpdateMoveAmounts;
        interplanetaryMode.Move.canceled += cameraController.Interplanetary.UpdateMoveAmounts;
        interplanetaryMode.Zoom.performed += cameraController.Interplanetary.Zoom;
        interplanetaryMode.ChoosePlanet.performed += planetChooser.Choose;

        var planetaryMode = Controls.PlanetaryMode;
        planetaryMode.Rotate.performed += cameraController.Planetary.UpdateRotateAmounts;
        planetaryMode.Rotate.canceled += cameraController.Planetary.UpdateRotateAmounts;
        planetaryMode.Zoom.performed += cameraController.Planetary.Zoom;
        planetaryMode.ChooseMenu.performed += ctx => planetaryMenuChooser.Choose();

        Controls.Gameplay.CastRay.performed += ctx => raycast.Shoot(); 
    }
}