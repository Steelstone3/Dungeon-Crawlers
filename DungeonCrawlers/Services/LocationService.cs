using DungeonCrawlers.States;

namespace DungeonCrawlers.Services
{
    public class LocationService : ILocationService
    {
        public LocationService( )
        {
        }

        public void GenerateLocations(ILocationController locationController)
        {
            locationController.GenerateDungeons();
            locationController.GenerateSettlements();
        }
    }
}