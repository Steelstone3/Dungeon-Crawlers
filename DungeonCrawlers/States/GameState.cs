using DungeonCrawlers.Contracts;

namespace DungeonCrawlers.States
{
    public abstract class GameState : IGameState
    {
        private IDisplayer _diplayer;
        private IGameController _gameController;

        public GameState(IDisplayer displayer, IGameController gameController)
        {
            _diplayer = displayer;
            _gameController = gameController;
        }

        public abstract void StartState();

        public abstract void StopState();

        public void GoToState(IGameState newState)
        {
            _gameController.CurrentGameState = newState;
            _gameController.CurrentGameState.StartState();
        }
    }
}