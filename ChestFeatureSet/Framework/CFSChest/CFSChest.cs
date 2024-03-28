using Microsoft.Xna.Framework;

namespace ChestFeatureSet.Framework.CFSChest
{
    public class CFSChest
    {
        public Vector2 ChestTileLocation { get; }
        public string LocationName { get; }

        public CFSChest(Vector2 chestTileLocation, string locationName)
        {
            this.ChestTileLocation = chestTileLocation;
            this.LocationName = locationName;
        }
    }

    public class SaveCFSChest
    {
        public readonly IEnumerable<CFSChest> Chests;

        public SaveCFSChest(IEnumerable<CFSChest> chests)
        {
            this.Chests = chests;
        }
    }
}
