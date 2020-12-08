using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform cameraHolderTransform;
    [SerializeField] private Transform controllerHolderTransform;

    [SerializeField] private float zoomDistance;
    [SerializeField] private float zoomSmoothSpeed;
    [SerializeField] private float modeTransitionDistanceFactor;    //todo need better name

    [Header("Planetary Mode")] 
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float minCameraDistanceFactor;

    [Header("Interplanetary Mode")] 
    [SerializeField] private float movementSpeed;
    [SerializeField] private float movementSmoothSpeed;
    [SerializeField] private float maxCameraDistance;
    [SerializeField] private float minInterplanetaryCameraDistance;
    [SerializeField] private Vector3 cameraRotation;
    [SerializeField] private Vector2 movementBoundaries;
    
    public PlanetaryCameraController Planetary { get; private set; }
    public InterplanetaryCameraController Interplanetary { get; private set; }

    private CameraManipulator _cameraManipulator;
    private ControllerManipulator _controllerManipulator;

    private void Start()
    {
        var cameraTransform = GetComponentInChildren<Camera>().transform;
        var controllerTransform = transform;
        _cameraManipulator = new CameraManipulator(cameraTransform, cameraHolderTransform);
        _controllerManipulator = new ControllerManipulator(controllerTransform, controllerHolderTransform);
        
        Planetary = new PlanetaryCameraController(_cameraManipulator, _controllerManipulator);
        UpdatePlanetaryParameters();

        Interplanetary = new InterplanetaryCameraController(_cameraManipulator, _controllerManipulator);
        UpdateInterplanetaryParameters();
        
        GameState.Get.ModeChanged += HandleModeChange;
    }
    
    private void Update()
    {
        _cameraManipulator.MoveCameraTowardsHolder(zoomSmoothSpeed);
        _controllerManipulator.MoveControllerTowardsHolder(movementSmoothSpeed);
        switch (GameState.Get.CurrentMode)
        {
            case GameState.Mode.Planetary:
                Planetary.MakeRotation();
                break;
            case GameState.Mode.Interplanetary:
                Interplanetary.MakeMovement();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        #if UNITY_EDITOR
                UpdatePlanetaryParameters();
                UpdateInterplanetaryParameters();
        #endif
    }

    private void UpdatePlanetaryParameters()
    {
        Planetary.RotationSpeed = rotationSpeed;
        Planetary.ZoomDistance = zoomDistance;
    }

    private void UpdateInterplanetaryParameters()
    {
        Interplanetary.MovementBoundaries = movementBoundaries;
        Interplanetary.MovementSpeed = movementSpeed;
        Interplanetary.ZoomSpeed = zoomDistance;
        Interplanetary.MaxCameraDistance = maxCameraDistance;
        Interplanetary.MinCameraDistance = minInterplanetaryCameraDistance;
    }
    
    private void HandleModeChange(GameState.Mode newMode)
    {
        switch (newMode)
        {
            case GameState.Mode.Planetary:
                var radius = GameState.Get.CurrentFocus.GetComponent<Planet>().Radius;
                var modeTransitionDistance = radius * modeTransitionDistanceFactor;
                var minPlanetaryCameraDistance = radius * minCameraDistanceFactor;

                Planetary.HandleModeChangeToPlanetary(modeTransitionDistance, minPlanetaryCameraDistance);
                break;
            case GameState.Mode.Interplanetary:
                Interplanetary.HandleModeChangeToInterplanetary(cameraRotation);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        } 
    }
}