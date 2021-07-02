using DungeonCrawlers.Contracts;

namespace DungeonCrawlers.States
{
    public class ExplorationState : GameState
    {
        public ExplorationState(IDisplayer displayer, IGameController gameController, ICharacterController characterController) : base(displayer, gameController)
        {

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