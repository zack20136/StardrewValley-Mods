namespace ChestFeatureSet.Framework.CFSItem
{
    public class CFSItem
    {
        public string ItemId { get; }
        public int Quality { get; }

        public CFSItem(string itemId, int quality)
        {
            this.ItemId = itemId;
            this.Quality = quality;
        }
    }

    public class SaveCFSItem
    {
        public readonly IEnumerable<CFSItem> Items;

        public SaveCFSItem(IEnumerable<CFSItem> items)
        {
            this.Items = items;
        }
    }
}
