using System;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Get { get; private set; }
    
    public GameObject CurrentFocus { get; set; }
    public Mode CurrentMode { get; set; } = Mode.Interplanetary;

    private void Awake()
    {
        if (Get != null)    //TODO get rid of this in final build
            Debug.LogError("Multiple occurrences of GameState. There should be only one GameState in any time.");
        Get = this;
    }

    public enum Mode
    {
        Planetary,
        Interplanetary
    }
}
