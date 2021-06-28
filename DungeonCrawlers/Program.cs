using DungeonCrawlers.Controllers.Characters;
using DungeonCrawlers.Controllers.Game;
using DungeonCrawlers.Game;
using DungeonCrawlersTests;

namespace DungeonCrawlers
{
    class Program
    {
        static void Main( string[] args )
        {
            var game = new LaunchGame();
            game.StartGame(new GameController(), new CharacterPartyController());
        }
    }
}
