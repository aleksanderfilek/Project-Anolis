using System;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private ActionActivator actionActivator;
    
    public static GameState Get { get; private set; }
    public event Action<Mode> ModeChanged;

    public GameObject CurrentFocus { get; private set; }
    public Mode CurrentMode { get; private set; }

    private void Awake()
    {
        #if UNITY_EDITOR
            if (Get != null)
                Debug.LogError("Multiple occurrences of GameState. There should be only one GameState in any time.");
        #endif
        Get = this;
    }

    public void ChangeModeToPlanetary(GameObject focusedPlanet)
    {
        CurrentFocus = focusedPlanet;
        CurrentMode = Mode.Planetary;
        actionActivator.SwitchCurrentActionMapTo("PlanetaryMode");
        OnStateChanged(Mode.Planetary);
    }

    public void ChangeModeToInterplanetary()
    {
        CurrentMode = Mode.Interplanetary;
        actionActivator.SwitchCurrentActionMapTo("InterplanetaryMode");
        OnStateChanged(Mode.Interplanetary); 
    }

    private void OnStateChanged(Mode newMode)
    {
        ModeChanged?.Invoke(newMode);
    }

    public enum Mode
    {
        Planetary,
        Interplanetary
    }
}
