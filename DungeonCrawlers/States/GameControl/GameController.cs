namespace DungeonCrawlers.States.GameControl
{
    public class GameController : IGameController
    {
        public IGameState CurrentGameState { get; set; }
    }
}