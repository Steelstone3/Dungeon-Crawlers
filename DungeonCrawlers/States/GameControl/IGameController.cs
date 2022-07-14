namespace DungeonCrawlers.States.GameControl
{
    public interface IGameController
    {
        IGameState CurrentGameState { get; set; }
    }
}