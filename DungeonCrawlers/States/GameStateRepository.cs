namespace DungeonCrawlers.States
{
    public class GameStateRepository : IGameStateRepository
    {
        public IGameState GameState { get; set; }
    }
}