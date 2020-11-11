using UnityEngine;
using UnityEngine.InputSystem;

namespace Interaction
{
    public class PlanetChooser : Chooser
    {
        //todo remove invisible button and change clicking to action in input system
        
        [SerializeField] private Raycast raycast;
        [SerializeField] private PlanetSelector planetSelector;
        [SerializeField] private CameraManipulator _cameraManipulator;
        
        public void OnChoose(InputAction.CallbackContext ctx)
        {
            if (!ctx.performed || !raycast.IsSomethingHit)
                return;
            
            planetSelector.UpdateSelector();
            if (planetSelector.SelectedPlanet == null) 
                return;
            
            GameState.Get.CurrentFocus = planetSelector.SelectedPlanet;
            //_cameraManipulator.CenterAtPlanet(GameState.Get.CurrentFocus); //todo move to callback for event mode changed
            //actionActivator.SwitchCurrentActionMap("PlanetaryMode");
            GameState.Get.ChangeModeToPlanetary();
        }
    }
}