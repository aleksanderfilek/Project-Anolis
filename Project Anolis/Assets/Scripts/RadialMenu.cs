using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenu : MonoBehaviour
{
    private Builder _builder;
    
    [SerializeField] private List<TileContent> _buildingList;

    private Tile _tile;
    private Transform _planetTransform;

    public RadialMenu(Tile tile, Transform planetTransform)
    {
        _tile = tile;
        _planetTransform = planetTransform;
    }

    private void Awake()
    {
        var _builder = GetComponent<Builder>();
    }

    public void Show()
    {
        Debug.Log("Press 1 to select building A");
    }
}
