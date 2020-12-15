using UnityEngine;

// This is a component to allow button keeping a reference
// to a planet assigned by PlaneMenu
public class PlanetButton : MonoBehaviour
{
    public GameObject Planet { get; set; }

    public void ChangeFocusToThis()
    {
        GameState.Get.ChangeModeToPlanetary(Planet.gameObject);
    }
}
