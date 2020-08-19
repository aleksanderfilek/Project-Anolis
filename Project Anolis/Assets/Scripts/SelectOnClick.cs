using UnityEngine;

public class SelectOnClick : MonoBehaviour
{
    [SerializeField] private Planet _planet;

    private int _triangleIndex;
    private void Update()
    {
        if (!Input.GetMouseButtonDown(0))
            return;
        ShootRay();
    }

    private void PrintTile()
    {
        print("Selected tile normal: " + _planet.Tiles[_triangleIndex].normal);
    }

    private void ShootRay()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hitData, 1000))
        {
            _triangleIndex = hitData.triangleIndex;
            PrintTile();
        }
    }
}
