using DungeonCrawlers.Display;
using DungeonCrawlers.Entities;
using DungeonCrawlers.States.GameControl;

namespace DungeonCrawlers.States
{
    public class DungeonState : GameState
    {
        private readonly IDisplayer displayer;
        private readonly IGameController gameController;
        private readonly ICharacter player;
        private readonly IWorld world;

        public DungeonState(IDisplayer displayer, IGameController gameController, ICharacter character, IWorld world) : base(gameController)
        {
            this.displayer = displayer;
            this.gameController = gameController;
            this.player = character;
            this.world = world;
        }

        public override void StartState()
        {
            displayer.WriteLine("Dungeon entered...");
            GoToState(new CombatState(displayer, gameController, player, world));
        }
    }
}