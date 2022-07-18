using DungeonCrawlers.Display;
using DungeonCrawlers.Entities;
using DungeonCrawlers.States.GameControl;

namespace DungeonCrawlers.States
{
    public class CombatState : GameState
    {
        private IDisplayer displayer;
        private IGameController gameController;
        private ICharacter player;
        private IWorld world;

        public CombatState(IDisplayer displayer, IGameController gameController, ICharacter player, IWorld world) : base(gameController)
        {
            this.displayer = displayer;
            this.gameController = gameController;
            this.player = player;
            this.world = world;
        }

        public override void StartState()
        {
            displayer.Write("Combat started...");
            GoToState(new DungeonState(displayer, gameController, player, world));
        }
    }
}