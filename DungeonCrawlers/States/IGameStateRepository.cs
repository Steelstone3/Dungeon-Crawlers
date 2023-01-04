namespace DungeonCrawlers.States
{
    public interface IGameStateRepository
    {
        IGameState GameState { get; set; }
    }
}