namespace DungeonCrawlers.Controllers
{
    public interface IGameController
    {
        void SpawnMonsters(int quantity, int[] seeds);
        void StartCombat();
    }
}