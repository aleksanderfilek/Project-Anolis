using System;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private ActionActivator actionActivator;
    
    public static GameState Get { get; private set; }
    public event Action<Mode> ModeChanged; //todo think about changing that event to two events for planetary and interplanetary

    public GameObject CurrentFocus { get; set; }
    public Mode CurrentMode { get; private set; } = Mode.Interplanetary;

    private void Awake()
    {
        if (Get != null)    //TODO get rid of this in final build
            Debug.LogError("Multiple occurrences of GameState. There should be only one GameState in any time.");
        Get = this;
    }

    public void ChangeModeToPlanetary()
    {
        CurrentMode = Mode.Planetary;
        actionActivator.SwitchCurrentActionMap("PlanetaryMode");
        OnStateChanged(Mode.Planetary);
    }

    public void ChangeModeToInterplanetary()
    {
        CurrentMode = Mode.Interplanetary;
        actionActivator.SwitchCurrentActionMap("InterplanetaryMode");
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
