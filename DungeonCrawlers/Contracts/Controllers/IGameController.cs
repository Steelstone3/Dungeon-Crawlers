using DungeonCrawlers.States;

namespace DungeonCrawlers.Contracts
{
    public interface IGameController
    {
        IGameState CurrentGameState { get; set; }
    }
}