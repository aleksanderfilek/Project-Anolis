namespace Interaction
{
    public class TileSelector : Selector
    {
        public Tile SelectedTile { get; private set; }

        protected override bool IsValidForSelection()
        {
            return raycast.IsSomethingHit && raycast.HitData.transform.CompareTag("Planet");
        }

        protected override void Select()
        {
            var hitData = raycast.HitData;
            var planet = hitData.transform.gameObject.GetComponent<Planet>();
            SelectedTile = planet.Tiles[hitData.triangleIndex];
        }

        protected override void ClearSelection()
        {
            SelectedTile = null;
        }
    }
}