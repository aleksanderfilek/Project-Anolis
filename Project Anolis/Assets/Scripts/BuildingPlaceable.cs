using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Building", menuName = "Custom/Building")]
public class BuildingPlaceable : Placeable
{
    public int cost;
    public ResourceType resourceType;
}
