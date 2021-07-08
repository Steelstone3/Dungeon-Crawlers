using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.States;

namespace DungeonCrawlers.Services
{
    public class LocationService : ILocationService
    {
        public void GenerateLocations(ILocationController locationController, ILocationBuilder locationBuilder)
        {
            locationController.GenerateDungeons(locationBuilder);
            locationController.GenerateSettlements(locationBuilder);
        }
    }
}