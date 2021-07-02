namespace DungeonCrawlers.Contracts.Controllers
{
    public interface IDungeonController
    {
        void GenerateRooms();
        void GenerateEncounters();
    }
}