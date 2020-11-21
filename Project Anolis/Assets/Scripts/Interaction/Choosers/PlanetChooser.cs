using UnityEngine;
using UnityEngine.InputSystem;

namespace Interaction
{
    public class PlanetChooser : MonoBehaviour
    {
        [SerializeField] private Raycast raycast;
        [SerializeField] private PlanetSelector planetSelector;

        public void Choose(InputAction.CallbackContext context)
        {
            if (!context.performed || !raycast.IsSomethingHit)
                return;

            planetSelector.UpdateSelector();
            if (planetSelector.SelectedPlanet == null)
                return;

            GameState.Get.CurrentFocus = planetSelector.SelectedPlanet;
            GameState.Get.ChangeModeToPlanetary();
        }
    }
}