using DungeonCrawlers.States;
using DungeonCrawlers.States.Interfaces;
using Xunit;

namespace DungeonCrawlersTests.States
{
    public class GameRepositoryShould
    {
        private readonly IGameRepository gameRepository = new GameRepository();

        [Fact]
        public void ContainsCharacterParty()
        {
            // Then
            Assert.NotNull(gameRepository.CharacterParty);
            Assert.Empty(gameRepository.CharacterParty);
        }

        [Fact]
        public void ContainsDungeon()
        {
            // Then
            Assert.Null(gameRepository.Dungeon);
        }
    }
}