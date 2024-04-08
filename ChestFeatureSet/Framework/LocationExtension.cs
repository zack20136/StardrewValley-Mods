using StardewValley;

namespace ChestFeatureSet.Framework
{
    public static class LocationExtension
    {
        public static string[] FarmArea { get; } = new string[] {
            "Farm", "FarmHouse", "Cellar", "Greenhouse", "FarmCave", "Shed", "Big Shed",
            "Coop", "Big Coop", "Deluxe Coop", "Barn", "Big Barn", "Deluxe Barn", "Slime Hutch"};

        /// <summary>
        /// Get all game's locations
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<GameLocation> GetAllLocations()
        {
            return Game1.locations.Concat(
                from location in Game1.locations
                where location.IsBuildableLocation()
                from building in location.buildings
                where building.indoors.Value != null
                select building.indoors.Value
            );
        }
    }
}
