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
            var presenter = new Presenter();
            var gamePresenter = new GamePresenter(presenter);
            var gameRepository = new GameRepository();
            var characterCreation = new CharacterCreationSystem(gamePresenter);
            var monsterCreation = new MonsterCreationSystem();
            var combat = new CombatSystem(presenter, seededRandom);

            var gameController = new GameController(presenter, gameRepository, monsterCreation, combat);

            IGameStateRepository gameStateRepository = new GameStateRepository();

            new NewGameState(gameStateRepository, presenter).StartState();

            var quantity = (int)seededRandom.GetSeededRandom(random.Next(), 1, 25);

            gameController.SpawnMonsters(quantity, seededRandom.CreateSeeds(quantity));

            gameController.StartCombat();

        }
    }
}
