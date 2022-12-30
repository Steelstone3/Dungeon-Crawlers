using System.Linq;
using DungeonCrawlers.Presenters;
using DungeonCrawlers.States;
using DungeonCrawlersTests.Systems;

namespace DungeonCrawlers.Controllers
{
    public class GameController : IGameController
    {
        private readonly IPresenter presenter;
        private readonly IGameState state;
        private readonly ICharacterCreationSystem characterCreation;

        public GameController(IPresenter presenter, IGameState state, ICharacterCreationSystem characterCreation)
        {
            this.presenter = presenter;
            this.state = state;
            this.characterCreation = characterCreation;
        }

        public void StartGame(int[] seeds)
        {
            var characterParty = characterCreation.CreateMultiple(3, seeds).ToList();
            characterParty.Add(characterCreation.Create());

            state.CharacterParty.AddRange(characterParty);

            presenter.PrintParty(characterParty);
        }
    }
}