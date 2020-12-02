using UnityEngine;

[RequireComponent(typeof(AnolisControlsActionActivator))]
public abstract class AnolisControlsActionCallbackConnection : MonoBehaviour
{
    protected GameplayControls Controls;
    public void SetControls(GameplayControls controls)
    {
        Controls = controls;
    }

    public void Connect()
    {
        #if UNITY_EDITOR
            if (Controls == null)
            {
                Debug.LogError("Controls (inputaction asset) reference not set. Most probably SetControls function need to be invoked first in ActionActivator.");
            }
        #endif
       
        ConnectActionsWithCallbacks();
    }
    
    protected abstract void ConnectActionsWithCallbacks();
}