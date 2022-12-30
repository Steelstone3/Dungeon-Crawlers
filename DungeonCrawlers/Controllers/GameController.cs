using DungeonCrawlers.Presenters;
using DungeonCrawlers.States;
using DungeonCrawlers.Systems;
using DungeonCrawlersTests.Systems;

namespace DungeonCrawlers.Controllers
{
    public class GameController : IGameController
    {
        private readonly IPresenter presenter;
        private readonly IGameState state;
        private readonly ICharacterCreationSystem characterCreation;
        private readonly IMonsterCreationSystem monsterCreation;

        public GameController(IPresenter presenter, IGameState state, ICharacterCreationSystem characterCreation, Systems.IMonsterCreationSystem monsterCreation)
        {
            this.presenter = presenter;
            this.state = state;
            this.characterCreation = characterCreation;
            this.monsterCreation = monsterCreation;
        }

        public void StartGame(int[] seeds)
        {
            state.CharacterParty.AddRange(characterCreation.CreateMultiple(3, seeds));
            state.CharacterParty.Add(characterCreation.Create());

            presenter.PrintParty(state.CharacterParty);
        }

        public void SpawnMonsters(int quantity, int[] seeds)
        {
            state.MonsterParty.AddRange(monsterCreation.CreateMultiple(quantity, seeds));

            presenter.PrintParty(state.MonsterParty);
        }
    }
}