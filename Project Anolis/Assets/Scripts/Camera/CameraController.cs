using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform holderTransform;

    [SerializeField] private float zoomDistance;
    [SerializeField] private float zoomSpeed;
    [SerializeField] private float modeTransitionDistanceFactor;    //todo need better name

    [Header("Planetary Mode")] 
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float minCameraDistanceFactor;

    [Header("Interplanetary Mode")] 
    [SerializeField] private float movementSpeed;
    [SerializeField] private float maxCameraDistance;
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
        _cameraManipulator = new CameraManipulator(cameraTransform, holderTransform);
        _controllerManipulator = new ControllerManipulator(controllerTransform);
        
        Planetary = new PlanetaryCameraController(_cameraManipulator, _controllerManipulator, cameraTransform, controllerTransform);
        UpdatePlanetaryParameters();

        Interplanetary = new InterplanetaryCameraController(_cameraManipulator, _controllerManipulator, controllerTransform, cameraTransform);
        UpdateInterplanetaryParameters();
    }

    private void UpdatePlanetaryParameters()
    {
        Planetary.RotationSpeed = rotationSpeed;
        Planetary.ZoomDistance = zoomDistance;
        Planetary.MinCameraDistanceFactor = minCameraDistanceFactor;
        Planetary.ModeTransitionDistanceFactor = modeTransitionDistanceFactor;
    }

    private void UpdateInterplanetaryParameters()
    {
        Interplanetary.MovementBoundaries = movementBoundaries;
        Interplanetary.CameraRotation = cameraRotation;
        Interplanetary.MovementSpeed = movementSpeed;
        Interplanetary.ZoomSpeed = zoomDistance;
        Interplanetary.MaxCameraDistance = maxCameraDistance;
    }

    private void Update()
    {
        _cameraManipulator.MoveCameraTowardsHolder(zoomSpeed);
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
}