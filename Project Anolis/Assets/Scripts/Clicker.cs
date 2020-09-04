using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class Clicker : MonoBehaviour
{
    private Tile _selectedTile;
    private Transform _selectedPlanetTransform;

    private Builder _builder;
    private RadialMenu _radialMenu;

    private void Start()
    {
        _radialMenu = GetComponent<RadialMenu>();
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0))
            return;
        SelectTile();
        var radialMenu = new RadialMenu(_selectedTile, _selectedPlanetTransform);
        radialMenu.Show();
    }

    private void SelectTile()
    {
        try
        {
            _selectedTile = TileSelector.FromMousePosition(Input.mousePosition);
        }
        catch (NoTileSelected)
        {
            //ignored
        }
    }
}
