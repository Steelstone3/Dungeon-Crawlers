namespace DungeonCrawlers.Contracts.Game
{
    public interface IGameController
    {
        IGameState CurrentGameState { get; set; }
    }
}