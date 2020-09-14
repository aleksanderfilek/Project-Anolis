using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logistics
{
    public class TileSelector : MonoBehaviour
    {
        public Tile SelectedTile { get; set; }
        public Transform SelectedPlanetTransform { get; set; }

        public void SelectFromRaycast(RaycastHit hitData)
        {
            var planet = hitData.transform.gameObject.GetComponent<Planet>();
            SelectedTile = planet.Tiles[hitData.triangleIndex];
            SelectedPlanetTransform = hitData.transform;
        }
    }
}