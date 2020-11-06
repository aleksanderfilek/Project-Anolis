using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class ActionActivator : MonoBehaviour
{
    [SerializeField] private List<string> alwaysActivatedActions;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        foreach (var action in alwaysActivatedActions)
        {
            _playerInput.actions[action].Enable();
        }
    }

    private void Update()
    {
        if (GameState.Get.CurrentMode == GameState.Mode.Interplanetary)    //todo change!!!
           _playerInput.SwitchCurrentActionMap("InterplanetaryMode");
        else
        {
            // _playerInput.SwitchCurrentActionMap("PlanetaryMode");
        }
    }
}
