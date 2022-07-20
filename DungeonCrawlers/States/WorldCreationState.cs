using DungeonCrawlers.Display;
using DungeonCrawlers.Entities;
using DungeonCrawlers.States.GameControl;

namespace DungeonCrawlers.States
{
    public class WorldCreationState : GameState
    {
        private readonly IDisplayer displayer;
        private readonly IGameController gameController;
        private readonly ICharacter player;
        private readonly IWorldCreationSystem worldCreationSystem;

        public WorldCreationState(IDisplayer displayer, IGameController gameController, ICharacter player, IWorldCreationSystem worldCreationSystem) : base(gameController)
        {
            this.displayer = displayer;
            this.gameController = gameController;
            this.player = player;
            this.worldCreationSystem = worldCreationSystem;
        }

        public override void StartState()
        {
            displayer.WriteLine("World creation started...");
            var world = worldCreationSystem.Create();
            displayer.DrawMap(world.worldGrid, player);
            GoToState(new ExplorationState(displayer, gameController, player, world));
        }
    }
}