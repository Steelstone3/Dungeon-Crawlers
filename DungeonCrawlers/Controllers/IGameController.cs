namespace DungeonCrawlers.Controllers
{
    public interface IGameController
    {
        void StartGame(int[] seeds);
        void SpawnMonsters(int quantity, int[] seeds);
        void StartCombat();
    }
}