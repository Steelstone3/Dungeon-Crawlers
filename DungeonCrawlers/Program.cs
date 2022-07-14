using DungeonCrawlers.Display;
using DungeonCrawlers.States;
using DungeonCrawlers.States.GameControl;

namespace DungeonCrawlers
{
    class Program
    {
        static void Main( string[] args )
        {
            var displayer = new Displayer();
            var gameController = new GameController();

            new NewGameState(displayer, gameController).StartState();
        }
    }
}
