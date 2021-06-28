namespace DungeonCrawlers.Contracts.Game
{
    public interface IGameState
    {
        void StartState();
        void StopState();
        void GoToState( IGameState newState );
    }
}