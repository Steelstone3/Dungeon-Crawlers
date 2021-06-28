using DungeonCrawlers.Contracts.Character;
using DungeonCrawlers.Contracts.Game;

namespace DungeonCrawlers.States
{
    public abstract class GameState : IGameState
    {
        private readonly IGameController _gameController;
        private readonly ICharacterPartyController _locationController;

        public GameState(IGameController gameController, ICharacterPartyController characterPartyController)
        {
            _gameController = gameController;
            _locationController = characterPartyController;
        }

        public void GoToState(IGameState newState)
        {
            _gameController.CurrentGameState = newState;
            _gameController.CurrentGameState.StartState();
        }

        public abstract void StartState();
        public abstract void StopState();
    }
}