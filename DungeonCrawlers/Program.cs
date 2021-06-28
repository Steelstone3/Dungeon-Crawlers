using DungeonCrawlers.Presenters;
using DungeonCrawlers.Presenters.Interfaces;
using DungeonCrawlers.States;
using DungeonCrawlers.States.Interfaces;

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
