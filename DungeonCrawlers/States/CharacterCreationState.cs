using DungeonCrawlers.Display;
using DungeonCrawlers.States.GameControl;
using DungeonCrawlers.Systems;
using DungeonCrawlersTests.Systems;

namespace DungeonCrawlers.States
{
    public class CharacterCreationState : GameState
    {
        private readonly IDisplayer displayer;
        private readonly IGameController gameController;
        private readonly ICharacterCreationSystem characterCreationSystem;

        public CharacterCreationState(IDisplayer displayer, IGameController gameController, ICharacterCreationSystem characterCreationSystem) : base(gameController)
        {
            this.displayer = displayer;
            this.gameController = gameController;
            this.characterCreationSystem = characterCreationSystem;
        }

        public override void StartState()
        {
            displayer.WriteLine("Character creation started...");
            var player = characterCreationSystem.Create(displayer);
            GoToState(new WorldCreationState(displayer, gameController, player, new WorldCreationSystem()));
        }
    }
}