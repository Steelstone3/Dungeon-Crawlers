using DungeonCrawlers.Contracts;

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
            throw new System.NotImplementedException();
        }

        public override void StopState()
        {
            throw new System.NotImplementedException();
        }
    }
}