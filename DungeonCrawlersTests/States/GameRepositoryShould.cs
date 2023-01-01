using DungeonCrawlers.States;
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
        public void ContainsMonsterParty()
        {
            // Then
            Assert.NotNull(gameRepository.MonsterParty);
            Assert.Empty(gameRepository.MonsterParty);
        }
    }
}