using DungeonCrawlers.Display;
using DungeonCrawlers.Entities;
using DungeonCrawlers.States.GameControl;

namespace DungeonCrawlers.States
{
    public class ExplorationState : GameState
    {
        private readonly IDisplayer displayer;
        private readonly IGameController gameController;
        private readonly ICharacter player;
        private readonly IWorld world;

        public ExplorationState(IDisplayer displayer, IGameController gameController, ICharacter player, IWorld world) : base(gameController)
        {
            this.displayer = displayer;
            this.gameController = gameController;
            this.player = player;
            this.world = world;
        }

        public override void StartState()
        {
            
        }
    }
}