using UnityEngine;

public class SelectOnClick : MonoBehaviour
{
    private Planet _planet;
    [SerializeField] private Tile _tile;

    private void Awake()
    {
        _planet = transform.GetComponentInParent<Planet>();
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0))
            return;
        ShootRay();
    }

    private void ShootRay()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hitData, 1000))
        {
            OnPlanetHit(hitData);
        }
    }

    private void OnPlanetHit(RaycastHit hitData)
    {
        if (hitData.transform.tag != "Planet") 
            return;
        var triangleIndex = hitData.triangleIndex;
        ExtractTile(triangleIndex);
        PrintTile();
    }

    private void ExtractTile(int triangleIndex)
    {
        _tile = _planet.Tiles[triangleIndex];
    }

    private void PrintTile()
    {
        print("Selected tile normal:" + _tile.normal);
    }
}
