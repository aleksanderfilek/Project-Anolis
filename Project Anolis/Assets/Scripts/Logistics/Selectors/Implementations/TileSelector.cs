namespace Logistics
{
    public class TileSelector : Selector
    {
        public Tile SelectedTile { get; private set; }

        protected override bool IsValidForSelection()
        {
            return Raycast.IsSomethingHit && Raycast.HitData.transform.CompareTag("Planet");
        }

        protected override void Select()
        {
            var hitData = Raycast.HitData;
            var planet = hitData.transform.gameObject.GetComponent<Planet>();
            SelectedTile = planet.Tiles[hitData.triangleIndex];
        }

        protected override void ClearSelection()
        {
            SelectedTile = null;
        }
    }
}