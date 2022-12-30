using DungeonCrawlers.Presenters;
using DungeonCrawlersTests.Systems;

namespace DungeonCrawlers
{
    class Program
    {
        static void Main()
        {
            var gamePresenter = new GamePresenter(new Presenter());
            var characterCreationSystem = new CharacterCreationSystem(gamePresenter);

            characterCreationSystem.Create();
        }
    }
}
