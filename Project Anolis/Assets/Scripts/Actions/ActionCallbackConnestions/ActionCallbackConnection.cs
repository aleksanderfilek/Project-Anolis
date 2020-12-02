using UnityEngine;
using UnityEngine.InputSystem;

public abstract class ActionCallbackConnection : MonoBehaviour
{ 
    public abstract InputActionAsset GetInputActionAsset();
    public abstract void Connect();
}