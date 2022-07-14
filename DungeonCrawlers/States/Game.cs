namespace DungeonCrawlers.States
{
    public abstract class Game : IGame
    {
        private readonly IGameController gameController;

        public Game(IGameController gameController)
        {
            this.gameController = gameController;
        }

        public abstract void StartState();

        public void GoToState(IGame nextGameState)
        {
            gameController.CurrentGameState = nextGameState;
            gameController.CurrentGameState.StartState();
        }
    }
}