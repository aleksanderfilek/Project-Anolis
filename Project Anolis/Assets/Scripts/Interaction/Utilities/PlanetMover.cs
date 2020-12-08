using System.Collections;
using System.Collections.Generic;
using Interaction;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

//todo: really simple behaviour
public class PlanetMover : MonoBehaviour
{
    [SerializeField] private CameraController cameraController;
    [SerializeField] private PlanetSelector planetSelector;
    public bool CanMoveSomething { get; set; }
    private Vector3 offset;
    
    public void Start()
    {
        CanMoveSomething = false;
    }

    public void Update()
    {
        if (!CanMoveSomething) return;
        if (planetSelector.SelectedPlanet is null) return;
        if (GameState.Get.CurrentMode == GameState.Mode.Planetary) Disable();
        var controllerPosition = cameraController.transform.position;
        planetSelector.SelectedPlanet.transform.position = controllerPosition + offset; //todo: while moving a planet after changing it's size this line crashes. So the action is disabled during that
    }

    public void Switch(InputAction.CallbackContext context)
    {
        if (!CanMoveSomething) Enable();
        else Disable();
    }

    private void Enable()
    {
        planetSelector.UpdateSelector();
        if (planetSelector.SelectedPlanet == null) return;
        var controllerPosition = cameraController.transform.position;
        offset = planetSelector.SelectedPlanet.transform.position - controllerPosition;
        CanMoveSomething = true;
    }
    
    private void Disable()
    {
        CanMoveSomething = false;
    }
}
