using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float zoomSpeed;
    [SerializeField] private float modeTransitionHeight;

    [Header("Planetary Mode")] 
    [SerializeField] private float rotatingSpeed;
    [SerializeField] private float minCameraHeight;

    [Header("Interplanetary Mode")] 
    [SerializeField] private float movingSpeed;
    [SerializeField] private float maxCameraHeight;
    [SerializeField] private Vector3 fixedRotation;
    [SerializeField] private Vector2 boundaries;

    public PlanetaryCameraController Planetary { get; private set; }
    public InterplanetaryCameraController Interplanetary { get; private set; }

    private CameraManipulator _cameraManipulator;
    private ControllerManipulator _controllerManipulator;

    private void Start()
    {
        var cameraTransform = GetComponentInChildren<Camera>().transform;
        var controllerTransform = transform;
        _cameraManipulator = new CameraManipulator(cameraTransform);
        _controllerManipulator = new ControllerManipulator(controllerTransform);
        
        Planetary = new PlanetaryCameraController(_cameraManipulator, _controllerManipulator, cameraTransform, controllerTransform);
        UpdatePlanetaryParameters();

        Interplanetary = new InterplanetaryCameraController(_cameraManipulator, _controllerManipulator, controllerTransform, cameraTransform);
        UpdateInterplanetaryParameters();
    }

    private void UpdatePlanetaryParameters()
    {
        Planetary.RotatingSpeed = rotatingSpeed;
        Planetary.ZoomSpeed = zoomSpeed;
        Planetary.MinCameraHeight = minCameraHeight;
        Planetary.ModeTransitionHeight = modeTransitionHeight;
    }

    private void UpdateInterplanetaryParameters()
    {
        Interplanetary.Boundaries = boundaries;
        Interplanetary.FixedRotation = fixedRotation;
        Interplanetary.MoveSpeed = movingSpeed;
        Interplanetary.ZoomSpeed = zoomSpeed;
        Interplanetary.MaxCameraHeight = maxCameraHeight;
    }

    private void Update()
    {
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