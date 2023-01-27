using DungeonCrawlers.Presenters;
using DungeonCrawlers.States;

namespace DungeonCrawlers
{
    static class Program
    {
        static void Main()
        {
            IPresenter presenter = new Presenter();
            IGameStateRepository gameStateRepository = new GameStateRepository();

            new NewGameState(gameStateRepository, presenter).StartState();
        }
    }
}
