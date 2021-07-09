using DungeonCrawlers.Builders;
using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Contracts.Services;
using DungeonCrawlers.Controllers;
using DungeonCrawlers.Services;

namespace DungeonCrawlers.States
{
    public class DungeonState : GameState
    {
        private IDisplayer _displayer;
        private IGameController _gameController;
        private ICharacterController _characterController;
        private IDungeonController _dungeonController;

        public DungeonState(IDisplayer displayer, 
        IGameController gameController, 
        ICharacterController characterController,
        IDungeonController dungeonController) : base(displayer, gameController)
        {
            _displayer = displayer;
            _gameController = gameController;
            _characterController = characterController;
            _dungeonController = dungeonController;
        }

        public override void StartState()
        {
            _displayer.Write("Dungeon entered");
            _dungeonController.CurrentDungeon.StartDungeon();

            StopState();
        }

        public override void StopState()
        {
            _displayer.Write("Leaving dungeon");

            GoToState(new ExplorationState(_displayer, 
            _gameController, 
            _characterController, 
            new LocationService(), 
            _dungeonController,
            new DungeonBuilder(new EncounterBuilder(), new EnemyController())));
        }
    }
}