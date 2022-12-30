using DungeonCrawlers.States;
using Xunit;

namespace DungeonCrawlersTests.States
{
    public class GameStateShould
    {
        private readonly IGameState gameState = new GameState();

        [Fact]
        public void ContainsCharacterParty()
        {
            // Then
            Assert.NotNull(gameState.CharacterParty);
            Assert.Empty(gameState.CharacterParty);
        }

        [Fact]
        public void ContainsMonsterParty()
        {
            // Then
            Assert.NotNull(gameState.MonsterParty);
            Assert.Empty(gameState.MonsterParty);
        }
    }
}