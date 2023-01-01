using DungeonCrawlers.Presenters;
using DungeonCrawlers.States;
using DungeonCrawlers.Systems;

namespace DungeonCrawlers.Controllers
{
    public class GameController : IGameController
    {
        private readonly IPresenter presenter;
        private readonly IGameRepository state;
        private readonly IMonsterCreationSystem monsterCreation;
        private readonly ICombatSystem combat;

        public GameController(IPresenter presenter, IGameRepository state, IMonsterCreationSystem monsterCreation, ICombatSystem combat)
        {
            this.presenter = presenter;
            this.state = state;
            this.monsterCreation = monsterCreation;
            this.combat = combat;
        }

        public void SpawnMonsters(int quantity, int[] seeds)
        {
            state.MonsterParty.AddRange(monsterCreation.CreateMultiple(quantity, seeds));

            presenter.PrintParty(state.MonsterParty);
        }

        public void StartCombat()
        {
            presenter.Print("Combat started");

            var isPlayerInCombat = true;
            var isMonsterInCombat = true;

            while (isPlayerInCombat || isMonsterInCombat)
            {
                isPlayerInCombat = combat.PlayerTurn(state.CharacterParty, state.MonsterParty);
                isMonsterInCombat = combat.MonsterTurn(state.MonsterParty, state.CharacterParty);
            }
        }
    }
}