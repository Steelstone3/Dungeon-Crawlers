using DungeonCrawlers.Contracts.Builders;

namespace DungeonCrawlers.States
{
    public interface ILocationService
    {
        void GenerateLocations(ILocationController locationController, ILocationBuilder locationBuilder);
    }
}