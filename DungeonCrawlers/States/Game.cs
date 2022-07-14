namespace DungeonCrawlers.States
{
    public class Game
    {
        private IGame currentGameState;

        public Game(IGame currentGameState)
        {
            this.currentGameState = currentGameState;
        }

        public void GoToState(IGame nextGameState)
        {
            currentGameState = nextGameState;
            currentGameState.StartState();
        }
    }
}