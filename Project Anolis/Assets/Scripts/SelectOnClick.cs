using UnityEngine;

public class SelectOnClick : MonoBehaviour
{
    private Planet _planet;

    public Tile SelectedTile { get; private set; }

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
        if (!hitData.transform.CompareTag("Planet")) 
            return;
        _planet = hitData.transform.gameObject.GetComponent<Planet>();
        ExtractTile(hitData.triangleIndex);
        PrintTile();
    }

    private void ExtractTile(int triangleIndex)
    {
        SelectedTile = _planet.Tiles[triangleIndex];
    }

    private void PrintTile()
    {
        print($"Selected tile normal: {SelectedTile.normal} from planet {_planet.gameObject}");
    }
}
