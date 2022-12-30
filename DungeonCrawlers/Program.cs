using System;
using DungeonCrawlers.Controllers;
using DungeonCrawlers.Presenters;
using DungeonCrawlers.States;
using DungeonCrawlers.Systems;
using DungeonCrawlersTests.Systems;

namespace DungeonCrawlers
{
    class Program
    {
        static void Main()
        {
            var random = new Random();
            var seededRandom = new SeededRandomSystem();
            var seeds = new int[] { random.Next(), random.Next(), random.Next() };
            var presenter = new Presenter();
            var gamePresenter = new GamePresenter(presenter);
            var state = new GameState();
            var characterCreation = new CharacterCreationSystem(gamePresenter);
            var monsterCreation = new MonsterCreationSystem();

            var gameController = new GameController(presenter, state, characterCreation, monsterCreation);
            
            gameController.StartGame(seeds);
            
            int quantity = (int)seededRandom.GetSeededRandom(random.Next(), 1, 25);
            
            gameController.SpawnMonsters(quantity, SeededRandomSystem.CreateSeeds(quantity));
        }
    }
}
