using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Contracts.Services;
using DungeonCrawlers.Services;

namespace DungeonCrawlers.States
{
    public class DungeonState : GameState
    {
        private IDisplayer _displayer;
        private IGameController _gameController;
        private ICharacterController _characterController;
        private ILocationController _locationController;
        private IDungeonCreationService _dungeonCreationService;
        private IDungeonController _dungeonController;

        public DungeonState(IDisplayer displayer, 
        IGameController gameController, 
        ICharacterController characterController,
        ILocationController locationController, 
        IDungeonCreationService dungeonCreationService, 
        IDungeonController dungeonController) : base(displayer, gameController)
        {
            _displayer = displayer;
            _gameController = gameController;
            _characterController = characterController;
            _locationController = locationController;
            _dungeonCreationService = dungeonCreationService;
            _dungeonController = dungeonController;
        }

        public override void StartState()
        {
            _displayer.Write("Dungeon entered");
            _dungeonCreationService.GenerateDungeon(_dungeonController);

            StopState();
        }

        public override void StopState()
        {
            _displayer.Write("Leaving dungeon");

            GoToState(new ExplorationState(_displayer, 
            _gameController,
            _characterController,
            new LocationService(), 
            _locationController));
        }
    }
}