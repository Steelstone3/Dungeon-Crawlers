using DungeonCrawlers.Controllers;
using DungeonCrawlers.Helpers;
using DungeonCrawlers.States;

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
