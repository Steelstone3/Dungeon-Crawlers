using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Contracts.Services;
using DungeonCrawlers.Controllers;

namespace DungeonCrawlers.States
{
    public class ExplorationState : GameState
    {
        private IDisplayer _displayer;
        private IGameController _gameController;
        private ICharacterController _characterController;
        private ILocationService _locationService;
        private IDungeonController _dungeonController;
        private IDungeonBuilder _dungeonBuilder;

        public ExplorationState(IDisplayer displayer, 
        IGameController gameController, 
        ICharacterController characterController, 
        ILocationService locationService, 
        IDungeonController dungeonController, 
        IDungeonBuilder dungeonBuilder) : base(displayer, gameController)
        {
            _displayer = displayer;
            _gameController = gameController;
            _characterController = characterController;
            _locationService = locationService;
            _dungeonController = dungeonController;
            _dungeonBuilder = dungeonBuilder;
        }

        public override void StartState()
        {
            _displayer.Write("Exploration started...");

            _dungeonController.Dungeons = _locationService.GenerateDungeons(_dungeonController, _dungeonBuilder);
            _locationService.DisplayLocations(_displayer, _dungeonController);
            _dungeonController.CurrentDungeon = _locationService.SelectLocation(_displayer, _dungeonController.Dungeons);

            StopState();
        }

        public override void StopState()
        {
            _displayer.Write("Entering dungeon");
            
            GoToState(new DungeonState(_displayer, 
            _gameController, 
            _characterController,
            new CombatController(),
            _dungeonController,
            _dungeonController.CurrentDungeon));
        }
    }
}