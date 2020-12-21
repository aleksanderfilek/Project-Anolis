using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Resource", menuName = "Custom/Resource")]
public class Resource : ScriptableObject
{
    public ResourceType resourceType;
    public Sprite sprite;
}
