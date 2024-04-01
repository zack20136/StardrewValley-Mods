using StardewValley;

namespace ChestFeatureSet.Framework
{
    public static class LocationExtension
    {
        public static string[] FarmArea { get; } = new string[] { "Farm", "FarmHouse", "Cellar", "GreenHouse", "Coop", "Barn", "Slime Hutch", "Shed", "FarmCave" };

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
