using System;
using UnityEngine;

public static class TileSelector
{
    public static ref Tile FromMousePosition(Vector3 mousePosition)
    {
        var ray = Camera.main.ScreenPointToRay(mousePosition);
        var isHit = Physics.Raycast(ray, out var hitData, 1000);
        CheckShotResult(isHit, hitData);
        return ref ExtractTile(hitData);
    }

    private static void CheckShotResult(bool isHit, RaycastHit hitData)
    {
        if (!isHit)
            throw new NoTileSelected();
        if (!hitData.transform.CompareTag("Planet"))
            throw new WrongObjectSelected();
    }

    private static ref Tile ExtractTile(RaycastHit hitData)
    {
        var planet = hitData.transform.gameObject.GetComponent<Planet>();
        // Debug.Log("This Tile has index: " + hitData.triangleIndex);
        return ref planet.Tiles[hitData.triangleIndex];
    }
}

class NoTileSelected : Exception
{
}

class WrongObjectSelected : Exception
{
}
