using DungeonCrawlers.States.GameControl;

namespace DungeonCrawlers.States
{
    public abstract class GameState : IGameState
    {
        private readonly IGameController gameController;

        public GameState(IGameController gameController)
        {
            this.gameController = gameController;
        }

        public abstract void StartState();

        public void GoToState(IGameState nextGameState)
        {
            gameController.CurrentGameState = nextGameState;
            gameController.CurrentGameState.StartState();
        }

    }
}