using UnityEngine;

public class GameState : MonoBehaviour
{
    public GameObject currentFocus;
    public Mode currentMode;
    
    public enum Mode
    {
        Planetary,
        Interplanetary
    }
}
