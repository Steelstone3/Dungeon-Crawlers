using DungeonCrawlers.Builders;
using DungeonCrawlers.Contracts;
using DungeonCrawlers.Controllers;
using DungeonCrawlers.Services;

namespace DungeonCrawlers.States
{
    public class SettlementState : GameState
    {
        private IDisplayer _displayer;
        private IGameController _gameController;

        public SettlementState(IDisplayer displayer, IGameController gameController) : base(displayer, gameController)
        {
            _displayer = displayer;
            _gameController = gameController;
        }

        public override void StartState()
        {
            _displayer.Write("Settlement entered");

            StopState();
        }

        public override void StopState()
        {
            _displayer.Write("Leaving settlement");

            GoToState(new ExplorationState(_displayer, 
            _gameController, 
            new CharacterController(), 
            new LocationService(), 
            new LocationController(),
            new LocationBuilder(new EncounterBuilder(), new EnemyController())));
        }
    }
}