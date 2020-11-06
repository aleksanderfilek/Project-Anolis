using System;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlanetaryCameraController))]
[RequireComponent(typeof(InterplanetaryCameraController))]
public class CameraController : MonoBehaviour
{
    // todo enables and disables specific controllers when modes changes
    

    private PlanetaryCameraController _planetaryCameraController;

    private void Awake()
    {
        _planetaryCameraController = GetComponent<PlanetaryCameraController>();
    }



}