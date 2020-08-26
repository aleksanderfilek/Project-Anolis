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
