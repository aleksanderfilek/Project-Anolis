using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

namespace Logistics
{
    public class UnoptimalTileSelector
    {
        public static Tile ExtractTileFromPlanet(RaycastHit hitData)
        {
            if (!hitData.transform.CompareTag("Planet"))
                throw new NoTileSelected();
            var planet = hitData.transform.gameObject.GetComponent<Planet>();
            return planet.Tiles[hitData.triangleIndex];
        }

        public static Transform ExtractTransformFromPlanet(RaycastHit hitData)
        {
            if (!hitData.transform.CompareTag("Planet"))
                throw new NoTileSelected();
            return hitData.transform;
        }

    }

    class NoTileSelected : Exception
    { }
}