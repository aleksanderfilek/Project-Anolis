using System;
using Interaction;
using UnityEngine;

/// <summary>
/// Encapsulates initialisation and method calls that are not always obligatory, and depends on current scene.
/// </summary>
public class GameplayInit : MonoBehaviour
{
    private void Start()
    {
        GameState.Get.ChangeModeToInterplanetary();
    }
}