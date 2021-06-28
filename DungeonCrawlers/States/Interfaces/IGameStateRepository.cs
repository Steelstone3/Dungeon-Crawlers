namespace DungeonCrawlers.States.Interfaces
{
    public interface IGameStateRepository
    {
        IGameState GameState { get; set; }
    }
}