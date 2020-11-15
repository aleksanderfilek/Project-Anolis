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

    private void Start()
    {
        var cameraTransform = GetComponentInChildren<Camera>().transform;
        var controllerTransform = transform;
        _cameraManipulator = new CameraManipulator(controllerTransform, cameraTransform);
        Planetary = new PlanetaryCameraController(_cameraManipulator, cameraTransform, controllerTransform, rotatingSpeed, minCameraHeight, modeTransitionHeight, zoomSpeed);
        Interplanetary = new InterplanetaryCameraController(_cameraManipulator, controllerTransform, cameraTransform, fixedRotation, maxCameraHeight, movingSpeed, zoomSpeed, boundaries);
        _cameraManipulator.SetRotationTo(fixedRotation);
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
    }
}