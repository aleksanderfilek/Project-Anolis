using UnityEditor;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    private Tile _selectedTile;

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0))
            return;
        SelectTile();
        ShowRadialMenu();
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

    private void ShowRadialMenu()
    {
        throw new System.NotImplementedException();
    }
}
