using DungeonCrawlers.Presenters;
using DungeonCrawlers.Presenters.Interfaces;
using DungeonCrawlers.States.Interfaces;
using DungeonCrawlers.Systems;

namespace DungeonCrawlers.States
{
    public class NewGameState : GameState
    {
        private readonly IGameStateRepository gameStateRepository;
        private readonly IPresenter presenter;

        public NewGameState(IGameStateRepository gameStateRepository, IPresenter presenter) : base(gameStateRepository)
        {
            this.gameStateRepository = gameStateRepository;
            this.presenter = presenter;
        }

        public override void StartState()
        {
            presenter.Print("New game started");

            GoToState(new CharacterCreationState(gameStateRepository, presenter, new GameRepository(), new CharacterCreationSystem(new CharacterPresenter(presenter)), new SeededRandomSystem()));
        }
    }
}