﻿using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Interaction
{
    /// <summary>
    /// This encapsulates casting rays, it can shoot ray, and store its result.
    /// </summary>
    public class Raycast : MonoBehaviour
    {
        public bool IsSomethingHit { get; private set; }
        public RaycastHit HitData;

        public void Shoot()
        {
            var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            IsSomethingHit = Physics.Raycast(ray, out HitData, 1000);
        }
    }
}