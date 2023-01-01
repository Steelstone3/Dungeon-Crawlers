using DungeonCrawlers.Presenters;

namespace DungeonCrawlers.States
{
    public class NewGameState : GameState
    {
        private readonly IPresenter presenter;

        public NewGameState(IGameStateRepository gameStateRepository, IPresenter presenter) : base(gameStateRepository)
        {
            this.presenter = presenter;
        }

        public override void StartState()
        {
            presenter.Print("New game started");
        }
    }
}