using DungeonCrawlers.Presenters;
using DungeonCrawlers.Systems;

namespace DungeonCrawlers.States
{
    public class DungeonState : GameState
    {
        private readonly IPresenter presenter;
        private readonly IGameRepository gameRepository;
        private readonly IMonsterCreationSystem monsterCreation;
        private readonly ICombatSystem combatSystem;
        private readonly ISeededRandomSystem seededRandomSystem;

        public DungeonState(IGameStateRepository gameStateRepository, IPresenter presenter, IGameRepository gameRepository, IMonsterCreationSystem monsterCreation, ICombatSystem combatSystem, ISeededRandomSystem seededRandomSystem) : base(gameStateRepository)
        {
            this.presenter = presenter;
            this.gameRepository = gameRepository;
            this.monsterCreation = monsterCreation;
            this.combatSystem = combatSystem;
            this.seededRandomSystem = seededRandomSystem;
        }

        public override void StartState()
        {
            SpawnMonsters();
            StartCombat();
        }

        private void SpawnMonsters()
        {
            var quantity = seededRandomSystem.GetRandom(1, 10);

            gameRepository.MonsterParty.AddRange(monsterCreation.CreateMultiple((int)quantity, seededRandomSystem.CreateSeeds((int)quantity)));

            presenter.PrintParty(gameRepository.MonsterParty);
        }

        private void StartCombat()
        {
            presenter.Print("Combat started");

            var isPlayerInCombat = true;
            var isMonsterInCombat = true;

            while (isPlayerInCombat || isMonsterInCombat)
            {
                isPlayerInCombat = combatSystem.PlayerTurn(gameRepository.CharacterParty, gameRepository.MonsterParty);
                isMonsterInCombat = combatSystem.MonsterTurn(gameRepository.MonsterParty, gameRepository.CharacterParty);
            }
        }
    }
}