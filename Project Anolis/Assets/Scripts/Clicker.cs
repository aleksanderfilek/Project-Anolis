using UnityEngine;

public class Clicker : MonoBehaviour
{
    private void Update()
    {
        if (!Input.GetMouseButtonDown(0))
            return;
        try
        {
            Debug.Log("Selected tile: " + TileSelector.FromMousePosition(Input.mousePosition));
            // var tile = TileSelector.FromMousePosition(Input.mousePosition);
            // print("Neighbors IDs are: " + tile.neighbor1 + ", " + tile.neighbor2 + ", " + tile.neighbor3 + ".");
        }
        catch (NoTileSelected)
        {
            Debug.Log("You miss clicked");
        }
        catch (WrongObjectSelected)
        {
            Debug.Log("That is not even a planet");
        }
    }
}
