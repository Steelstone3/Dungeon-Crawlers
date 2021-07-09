using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Contracts.Services;

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

            //TODO AH User selection on location Listing Dungeons and Settlements
            //TODO AH An encounter chance on travelling to location and a traveling state that reveals the distance, time taken etc
            StopState();
        }

        public override void StopState()
        {
            //TODO AH Decision based on whether a settlement was picked or a dungeon
            _displayer.Write("Entering dungeon");
            
            GoToState(new DungeonState(_displayer, 
            _gameController, 
            _characterController, 
            _dungeonController));

            //Settlements are for party heal ups in taverns, buying equipment etc later on systems
            //_displayer.Write("Entering settlement");
            //GoToState(new SettlementState(_displayer, _gameController));
        }
    }
}