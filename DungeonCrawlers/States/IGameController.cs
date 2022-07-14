namespace DungeonCrawlers.States
{
    public interface IGameController
    {
        IGame CurrentGameState { get; set; }
    }
}