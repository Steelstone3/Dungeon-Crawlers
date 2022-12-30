using System;
using DungeonCrawlers.Controllers;
using DungeonCrawlers.Presenters;
using DungeonCrawlers.States;
using DungeonCrawlersTests.Systems;

namespace DungeonCrawlers
{
    class Program
    {
        static void Main()
        {
            var random = new Random();
            var seeds = new int[] { random.Next(), random.Next(), random.Next() };
            var presenter = new Presenter();
            var gamePresenter = new GamePresenter(presenter);
            var state = new GameState();
            var characterCreation = new CharacterCreationSystem(gamePresenter);

            var gameController = new GameController(presenter, state, characterCreation);
            gameController.StartGame(seeds);
        }
    }
}
