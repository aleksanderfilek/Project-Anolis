using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//todo remove PlayerInput and move binding here, because we use it only for binding actions with callbacks, and it adds
//that callback to all phases (started, performed, ended) which is stupid, because we must then check in callbacks that
//certain action is performed (because it will be invoked basicaly 3 time on every action)

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
}
