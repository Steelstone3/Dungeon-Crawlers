using DungeonCrawlers.Entities.Intefaces;
using DungeonCrawlers.Presenters.Interfaces;
using DungeonCrawlers.States.Interfaces;
using DungeonCrawlers.Systems.Interfaces;

namespace DungeonCrawlers.States
{
    public class DungeonState : GameState
    {
        private readonly IPresenter presenter;
        private readonly IGameRepository gameRepository;
        private readonly IDungeonCreationSystem dungeonCreation;
        private readonly ICombatSystem combatSystem;

        public DungeonState(IGameStateRepository gameStateRepository, IPresenter presenter, IGameRepository gameRepository, IDungeonCreationSystem dungeonCreation, ICombatSystem combatSystem) : base(gameStateRepository)
        {
            this.presenter = presenter;
            this.gameRepository = gameRepository;
            this.dungeonCreation = dungeonCreation;
            this.combatSystem = combatSystem;
        }

        public override void StartState()
        {
            SpawnDungeon();
            StartDungeon();
        }

        private void SpawnDungeon() => gameRepository.Dungeon = dungeonCreation.CreateDungeon();

        private void StartDungeon()
        {
            presenter.Print("Combat started");

            foreach (var room in gameRepository.Dungeon.Rooms)
            {
                StartCombat(room);
            }
        }

        private void StartCombat(IRoom room)
        {
            var isPlayerInCombat = true;
            var isMonsterInCombat = true;

            while (isPlayerInCombat || isMonsterInCombat)
            {
                isPlayerInCombat = combatSystem.PlayerTurn(gameRepository.CharacterParty, room.Monsters);
                isMonsterInCombat = combatSystem.MonsterTurn(room.Monsters, gameRepository.CharacterParty);
            }
        }
    }
}