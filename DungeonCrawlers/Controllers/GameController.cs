using DungeonCrawlers.Contracts;
using DungeonCrawlers.States;

namespace DungeonCrawlers.Controllers
{
    public class GameController : IGameController
    {
        public IGameState CurrentGameState { get; set; }
    }
}