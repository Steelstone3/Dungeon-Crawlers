using DungeonCrawlers.Components.Interfaces;
using DungeonCrawlers.Entities;
using DungeonCrawlers.Entities.Intefaces;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Entities
{
    public class MonsterShould
    {
        private readonly Mock<IName> name = new();
        private readonly Mock<IRace> race = new();
        private readonly Mock<IHealth> health = new();
        private readonly Mock<IWeapon> weapon = new();
        private readonly IMonster monster;

        public MonsterShould()
        {
            monster = new Monster(name.Object, race.Object, health.Object, weapon.Object);
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

        [Fact]
        public void ContainsMonsterWeapon()
        {
            // Then
            Assert.NotNull(monster.Weapon);
        }
    }
}