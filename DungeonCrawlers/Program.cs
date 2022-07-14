using DungeonCrawlers.Display;
using DungeonCrawlers.States;

namespace DungeonCrawlers
{
    class Program
    {
        static void Main( string[] args )
        {
            var displayer = new Displayer();
            var gameController = new GameController();

            new NewGame(displayer, gameController).StartState();
        }
    }
}
