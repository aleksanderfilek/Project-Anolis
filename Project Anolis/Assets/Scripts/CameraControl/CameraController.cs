using System;
using UnityEngine;

namespace CameraControl
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform cameraHolderTransform;
        [SerializeField] private Transform controllerHolderTransform;

        [SerializeField] [Tooltip("Specifies how much camera holder will move per one zoom action")]
        private float zoomHolderSpeed;

        [SerializeField] [Tooltip("Specifies how fast camera will follow camera holder in each frame")]
        private float zoomFollowSpeed;


        [Header("Planetary Mode")] 
        
        [SerializeField] [Tooltip("Planet radius is multiplied by this value, and if camera holder passes resulting distance, mode will be changed to interplanetary")]
        private float maxDistanceFactor;

        [SerializeField] [Tooltip("Specifies how much controller holder will rotate in each frame")]
        private float rotationHolderSpeed;
        
        [SerializeField] [Tooltip("Specifies how fast controller will follow controller holder in each frame")]
        private float rotationFollowSpeed;
        
        [SerializeField] [Tooltip("Planet radius is multiplied by this value, and result is used to determine minimal distance that camera can move towards planet center")]
        private float minCameraDistanceFactor;

        [Header("Interplanetary Mode")] 
        [SerializeField] [Tooltip("Specifies how much controller holder will move in each frame")]
        private float movementSpeed;
        
        [SerializeField] [Tooltip("Specifies how fast controller will follow controller holder in each frame")]
        private float movementFollowSpeed;
        
        [SerializeField] [Tooltip("Determines the maximum distance that camera can be zoomed")]
        private float maxCameraDistance;
        
        [SerializeField] [Tooltip("Determines the minimum distance that camera can be zoomed")]
        private float minCameraDistance;
        
        [SerializeField] [Tooltip("Specifies angle that camera will be rotated in interplanetary mode")]
        private Vector3 cameraRotation;
        
        [SerializeField] [Tooltip("Specifies boundaries beyond which camera controller cannot be moved")]
        private Vector2 movementBoundaries;

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
            _cameraManipulator.MoveCameraTowardsHolder(zoomFollowSpeed);
            _controllerManipulator.MoveControllerTowardsHolder(movementFollowSpeed);
            _controllerManipulator.RotateControllerTowardsHolder(rotationFollowSpeed);
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
            Planetary.RotationSpeed = rotationHolderSpeed;
            Planetary.ZoomDistance = zoomHolderSpeed;
        }

        private void UpdateInterplanetaryParameters()
        {
            Interplanetary.MovementBoundaries = movementBoundaries;
            Interplanetary.MovementSpeed = movementSpeed;
            Interplanetary.ZoomSpeed = zoomHolderSpeed;
            Interplanetary.MaxCameraDistance = maxCameraDistance;
            Interplanetary.MinCameraDistance = minCameraDistance;
        }

        private void HandleModeChange(GameState.Mode newMode)
        {
            switch (newMode)
            {
                case GameState.Mode.Planetary:
                    var radius = GameState.Get.CurrentFocus.GetComponent<Planet>().Radius;
                    var modeTransitionDistance = radius * maxDistanceFactor;
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
}