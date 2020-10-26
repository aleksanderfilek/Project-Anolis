using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

[RequireComponent(typeof(PlayerInput))]
public class InputActionMapManager : MonoBehaviour
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
