using DungeonCrawlers.Contracts;

namespace DungeonCrawlers.States
{
    public class CharacterCreationState : GameState
    {
        private IDisplayer _displayer;
        private IGameController _gameController;
        private ICharacterCreationService _characterCreationService;
        private ICharacterController _characterController;

        public CharacterCreationState(IDisplayer displayer, IGameController gameController, ICharacterCreationService characterCreationService ,ICharacterController characterController) : base(displayer, gameController)
        {
            _displayer = displayer;
            _gameController = gameController;
            _characterCreationService = characterCreationService;
            _characterController = characterController;
        }

        public override void StartState()
        {
            _displayer.Write("Character creation");
            _characterCreationService.CreateCharacterParty(_characterController, 3);

            StopState();
        }

        public override void StopState()
        {
            _displayer.Write("Starting game...");
            GoToState(new ExplorationState(_displayer, _gameController, _characterController));
        }
    }
}