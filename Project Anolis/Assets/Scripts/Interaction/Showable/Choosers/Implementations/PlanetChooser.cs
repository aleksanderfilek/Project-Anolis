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
        
        public void Choose()
        {
            if (!raycast.IsSomethingHit)
                return;
            
            planetSelector.UpdateSelector();
            if (planetSelector.SelectedPlanet == null) 
                return;
            
            GameState.Get.CurrentFocus = planetSelector.SelectedPlanet;
            playerInput.SwitchCurrentActionMap("PlanetaryMode");
            Hide();
        }
    }
}