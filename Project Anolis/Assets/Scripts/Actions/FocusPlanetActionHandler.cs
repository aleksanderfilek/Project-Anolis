using Interaction;
using UnityEngine;
using UnityEngine.InputSystem;


public class FocusPlanetActionHandler : MonoBehaviour
{
    [SerializeField] private Raycast raycast;
    [SerializeField] private PlanetSelector planetSelector;

    public void HandleFocusPlanet(InputAction.CallbackContext context)
    {
        if (!context.performed || !raycast.IsSomethingHit)
            return;

        planetSelector.UpdateSelector();
        if (planetSelector.SelectedPlanet == null)
            return;

        GameState.Get.ChangeModeToPlanetary(planetSelector.SelectedPlanet);
    }
}