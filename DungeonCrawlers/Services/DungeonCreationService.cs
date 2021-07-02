using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Contracts.Services;
using DungeonCrawlers.Controllers;

namespace DungeonCrawlers.Services
{
    public class DungeonCreationService : IDungeonCreationService
    {
        public void GenerateDungeon(IDungeonController dungeonController)
        {
            dungeonController.GenerateRooms();
            dungeonController.GenerateEncounters();
        }
    }
}