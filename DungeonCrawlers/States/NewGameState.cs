using DungeonCrawlers.Display;
using DungeonCrawlers.States.GameControl;
using DungeonCrawlers.Systems;

namespace DungeonCrawlers.States
{
    public class NewGameState : GameState
    {
        private readonly IDisplayer displayer;
        private readonly IGameController gameController;

        public NewGameState(IDisplayer displayer, IGameController gameController) : base(gameController)
        {
            this.displayer = displayer;
            this.gameController = gameController;
        }

        public override void StartState()
        {
            displayer.Write("New game selected...");
            GoToState(new CharacterCreationState(displayer, gameController, new CharacterCreationSystem()));
        }
    }
}