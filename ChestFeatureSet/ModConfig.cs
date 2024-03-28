using StardewModdingAPI;

namespace ChestFeatureSet
{
    public sealed class ModConfig
    {
        // StashToChests
        public bool StashToChests { get; set; } = true;
        public bool OnlyStashToExistingStacks { get; set; } = false;
        public string StashLocationSetting { get; set; } = "Default"; // Default, Anywhere, AllFramBuilding
        public int StashRadius { get; set; } = 32;
        public SButton StashKey { get; set; } = SButton.B;

        // LockItems
        public bool LockItems { get; set; } = true;
        public SButton LockItemKey { get; set; } = SButton.LeftAlt;
        public SButton ResetLockItemKey { get; set; } = SButton.RightAlt;

        // CraftFromChests
        public bool CraftFromChests { get; set; } = true;
        public string CraftLocationSetting { get; set; } = "Default"; // Default, Anywhere, AllFramBuilding
        public int CraftRadius { get; set; } = -1;
        public SButton OpenCraftingPageKey { get; set; } = SButton.K;

        // PickUpChests
        public bool MoveChests { get; set; } = true;
        public SButton MoveChestKey { get; set; } = SButton.LeftShift;

        // Variable
        public string[] FarmArea { get; set; } = new string[] { "Farm", "FarmHouse", "Cellar", "FarmCave", "GreenHouse", "Barn", "Coop", "SlimeHutch", "AnimalHouse" };
    }
}
