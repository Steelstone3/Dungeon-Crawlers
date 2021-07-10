using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Contracts.Services;
using DungeonCrawlers.Controllers;
using DungeonCrawlers.Services;

namespace DungeonCrawlers.States
{
    public class ExplorationState : GameState
    {
        private IDisplayer _displayer;
        private IGameController _gameController;
        private ICharacterController _characterController;
        private ILocationService _locationService;
        private IDungeonService _dungeonService;
        private IDungeonController _dungeonController;
        private IDungeonBuilder _dungeonBuilder;

        public ExplorationState(IDisplayer displayer, 
        IGameController gameController, 
        ICharacterController characterController, 
        ILocationService locationService,
        IDungeonService dungeonService,
        IDungeonController dungeonController, 
        IDungeonBuilder dungeonBuilder) : base(displayer, gameController)
        {
            _displayer = displayer;
            _gameController = gameController;
            _characterController = characterController;
            _locationService = locationService;
            _dungeonService = dungeonService;
            _dungeonController = dungeonController;
            _dungeonBuilder = dungeonBuilder;
        }

        public override void StartState()
        {
            _displayer.Write("Exploration started...");

            _dungeonController.CurrentDungeon = _dungeonService.SelectDungeon(_displayer, _locationService, _dungeonController, _dungeonBuilder);
            
            StopState();
        }

        public override void StopState()
        {
            _displayer.Write("Entering dungeon");
            
            GoToState(new DungeonState(_displayer, 
            _gameController, 
            _characterController,
            new CombatService(),
            new CombatController(),
            _dungeonService,
            _dungeonController));
        }
    }
}