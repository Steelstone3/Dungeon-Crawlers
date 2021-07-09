using DungeonCrawlers.Builders;
using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Controllers;
using DungeonCrawlers.Services;

namespace DungeonCrawlers.States
{
    public class CharacterCreationState : GameState
    {
        private IDisplayer _displayer;
        private IGameController _gameController;
        private ICharacterCreationService _characterCreationService;
        private ICharacterBuilder _characterBuilder;
        private ICharacterController _characterController;

        public CharacterCreationState(IDisplayer displayer, 
        IGameController gameController, 
        ICharacterCreationService characterCreationService, 
        ICharacterBuilder characterBuilder, 
        ICharacterController characterController) : base(displayer, gameController)
        {
            _displayer = displayer;
            _gameController = gameController;
            _characterCreationService = characterCreationService;
            _characterBuilder = characterBuilder;
            _characterController = characterController;
        }

        public override void StartState()
        {
            _displayer.Write("Character creation");
            _characterCreationService.CreateCharacterParty(_displayer, _characterController, _characterBuilder, 3);

            StopState();
        }

        public override void StopState()
        {
            _displayer.Write("Starting game...");

            GoToState(new ExplorationState(_displayer, 
            _gameController, 
            _characterController, 
            new LocationService(), 
            new DungeonController(), 
            new DungeonBuilder(new EncounterBuilder(), new EnemyController())));
        }
    }
}