using DungeonCrawlers.Display;
using DungeonCrawlers.Entities;
using DungeonCrawlers.States.GameControl;
using DungeonCrawlers.Systems;

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
            displayer.Write("World creation started...");
            var world = worldCreationSystem.Create(displayer);
            GoToState(new ExplorationState(displayer, gameController, player, world));
        }
    }
}