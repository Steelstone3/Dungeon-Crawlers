using DungeonCrawlers.Contracts.Game;

namespace DungeonCrawlers.Controllers.Game
{
    public class GameController : IGameController
    {
        public IGameState CurrentGameState { get; set; }
    }
}