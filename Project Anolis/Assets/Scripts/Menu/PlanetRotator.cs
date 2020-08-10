using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menu
{
    public class PlanetRotator : MonoBehaviour
    {
        [SerializeField] private Vector3 vector;

        private void Update()
        {
            transform.Rotate(vector);
        }
    }
}
