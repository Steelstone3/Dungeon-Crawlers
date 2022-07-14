namespace DungeonCrawlers.States
{
    public class GameController : IGameController
    {
        public IGame CurrentGameState { get; set; }
    }
}