using UnityEngine;
using UnityEngine.InputSystem;

namespace Interaction
{
    public class PlanetChooser : Chooser
    {
        //todo remove invisible button and change clicking to action in input system
        
        [SerializeField] private Raycast raycast;
        [SerializeField] private PlanetSelector planetSelector;
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private CameraManipulator _cameraManipulator;
        
        public void Choose(InputAction.CallbackContext ctx)
        {
            if (!ctx.performed || !raycast.IsSomethingHit)
                return;
            
            planetSelector.UpdateSelector();
            if (planetSelector.SelectedPlanet == null) 
                return;
            
            GameState.Get.CurrentFocus = planetSelector.SelectedPlanet;
            _cameraManipulator.CenterAtPlanet(GameState.Get.CurrentFocus);
            playerInput.SwitchCurrentActionMap("PlanetaryMode");
            Hide();
        }
    }
}