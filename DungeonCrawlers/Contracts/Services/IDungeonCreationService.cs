using DungeonCrawlers.Contracts.Controllers;

namespace DungeonCrawlers.Contracts.Services
{
    public interface IDungeonCreationService
    {
        void GenerateDungeon(IDungeonController dungeonController);
    }
}