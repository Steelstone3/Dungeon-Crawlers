using DungeonCrawlers.Contracts;
using DungeonCrawlers.States;

namespace DungeonCrawlersTests
{
    public class GameController : IGameController
    {
        public IGameState CurrentGameState { get; set; }
    }
}