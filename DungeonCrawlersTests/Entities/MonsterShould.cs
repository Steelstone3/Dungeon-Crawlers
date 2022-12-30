using DungeonCrawlers.Components;
using DungeonCrawlers.Entities;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Entities
{
    public class MonsterShould
    {
        private readonly Mock<IName> name = new();
        private readonly Mock<IRace> race = new();
        private readonly Mock<IHealth> health = new();
        private readonly IMonster monster;

        public MonsterShould()
        {
            monster = new Monster(name.Object, race.Object, health.Object);
        }

        [Fact]
        public void ContainsMonsterName()
        {
            // Then
            Assert.NotNull(monster.Name);
        }

        [Fact]
        public void ContainsMonsterRace()
        {
            // Then
            Assert.NotNull(monster.Race);
        }

        [Fact]
        public void ContainsMonsterHealth()
        {
            // Then
            Assert.NotNull(monster.Health);
        }
    }
}