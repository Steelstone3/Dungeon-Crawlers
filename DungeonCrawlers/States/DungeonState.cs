using DungeonCrawlers.Builders;
using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Contracts.Game.Locations;
using DungeonCrawlers.Controllers;
using DungeonCrawlers.Services;

namespace DungeonCrawlers.States
{
    public class DungeonState : GameState
    {
        private IDisplayer _displayer;
        private IGameController _gameController;
        private ICharacterController _characterController;
        private ICombatController _combatController;
        private IDungeonController _dungeonController;
        private IDungeon _dungeon;

        public DungeonState(IDisplayer displayer,
        IGameController gameController, 
        ICharacterController characterController,
        ICombatController combatController,
        IDungeonController dungeonController,
        IDungeon dungeon) : base(displayer, gameController)
        {
            _displayer = displayer;
            _gameController = gameController;
            _characterController = characterController;
            _combatController = combatController;
            _dungeonController = dungeonController;
            _dungeon = dungeon;
        }

        public override void StartState()
        {
            _displayer.Write("Dungeon entered");
            _dungeonController.CurrentDungeon.StartDungeon(_dungeon.Rooms, _combatController);

            StopState();
        }

        public override void StopState()
        {
            _displayer.Write("Leaving dungeon");

            GoToState(new ExplorationState(_displayer, 
            _gameController, 
            _characterController, 
            new LocationService(), 
            _dungeonController,
            new DungeonBuilder(new EncounterBuilder(), new EnemyController())));
        }
    }
}