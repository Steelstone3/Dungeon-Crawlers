using DungeonCrawlers.States.Interfaces;

namespace DungeonCrawlers.States
{
    public abstract class GameState : IGameState
    {
        private readonly IGameStateRepository gameStateRepository;

        protected GameState(IGameStateRepository gameStateRepository)
        {
            this.gameStateRepository = gameStateRepository;
        }

        public abstract void StartState();

        public void GoToState(IGameState gameState)
        {
            gameStateRepository.GameState = gameState;
            gameStateRepository.GameState.StartState();
        }
    }
}