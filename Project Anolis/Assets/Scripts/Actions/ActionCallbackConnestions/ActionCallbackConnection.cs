using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Stores InputActionAsset and connects its actions to callbacks. 
/// </summary>
/// <remarks>
/// An Implementation of this abstract class should contain specific InputActionAsset (that stores actions) and all references to objects containing callbacks for those actions.
/// </remarks>
public abstract class ActionCallbackConnection : MonoBehaviour
{
    /// <summary>
    /// Getter for InputActionAsset that is used by this class.
    /// </summary>
    /// <returns>Specific InputActionAsset that is used by this class</returns>
    public abstract InputActionAsset GetInputActionAsset();
    
    /// <summary>
    /// Connects actions from stored InputActionAsset with their callbacks.
    /// </summary>
    public abstract void Connect();
}