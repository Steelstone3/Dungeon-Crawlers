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
        private readonly ICombatSystem combat;

        public GameController(IPresenter presenter, IGameState state, ICharacterCreationSystem characterCreation, Systems.IMonsterCreationSystem monsterCreation, ICombatSystem combat)
        {
            this.presenter = presenter;
            this.state = state;
            this.characterCreation = characterCreation;
            this.monsterCreation = monsterCreation;
            this.combat = combat;
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

        public void StartCombat()
        {
            presenter.Print("Combat started");
            combat.PlayerTurn(state.CharacterParty, state.MonsterParty);
        }
    }
}