using System.Linq;
using DungeonCrawlers.Presenters;
using DungeonCrawlersTests.Systems;

namespace DungeonCrawlers.Controllers
{
    public class GameController : IGameController
    {
        private readonly IPresenter presenter;
        private readonly ICharacterCreationSystem characterCreation;

        public GameController(IPresenter presenter, ICharacterCreationSystem characterCreation)
        {
            this.presenter = presenter;
            this.characterCreation = characterCreation;
        }

        public void StartGame(int[] seeds)
        {
            var characterParty = characterCreation.CreateMultiple(3, seeds).ToList();
            characterParty.Add(characterCreation.Create());

            presenter.PrintParty(characterParty);
        }
    }
}