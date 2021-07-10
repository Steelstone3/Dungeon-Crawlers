using DungeonCrawlers.Builders;
using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Controllers;
using DungeonCrawlers.Contracts.Game.Locations;
using DungeonCrawlers.Contracts.Services;
using DungeonCrawlers.Controllers;
using DungeonCrawlers.Services;

namespace DungeonCrawlers.States
{
    public class DungeonState : GameState
    {
        private IDisplayer _displayer;
        private IGameController _gameController;
        private ICharacterController _characterController;
        private ICombatService _combatService;
        private ICombatController _combatController;
        private IDungeonService _dungeonService;
        private IDungeonController _dungeonController;

        public DungeonState(IDisplayer displayer,
        IGameController gameController, 
        ICharacterController characterController,
        ICombatService combatService,
        ICombatController combatController,
        IDungeonService dungeonService,
        IDungeonController dungeonController) : base(displayer, gameController)
        {
            _displayer = displayer;
            _gameController = gameController;
            _characterController = characterController;
            _combatService = combatService;
            _combatController = combatController;
            _dungeonService = dungeonService;
            _dungeonController = dungeonController;
        }

        public override void StartState()
        {
            _displayer.Write("Dungeon entered");
            _dungeonService.StartDungeon(_displayer,_combatService, _combatController,  _characterController, _dungeonController.CurrentDungeon);

            StopState();
        }

        public override void StopState()
        {
            _displayer.Write("Leaving dungeon");

            GoToState(new ExplorationState(_displayer, 
            _gameController, 
            _characterController, 
            new LocationService(), 
            _dungeonService,
            _dungeonController,
            new DungeonBuilder(new EncounterBuilder(), new EnemyController())));
        }
    }
}