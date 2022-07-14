using DungeonCrawlers.Display;

namespace DungeonCrawlers.States
{
    public class NewGame : Game
    {
        private readonly IDisplayer displayer;
        private readonly IGameController gameController;

        public NewGame(IDisplayer displayer, IGameController gameController) : base(gameController)
        {
            this.displayer = displayer;
            this.gameController = gameController;
        }

        public override void StartState()
        {
            displayer.Write("New game selected...");

            // GoToState();
        }
    }
}