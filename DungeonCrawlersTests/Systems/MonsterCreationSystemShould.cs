using System.Linq;
using DungeonCrawlers.Presenters;
using DungeonCrawlers.Systems;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Systems
{
    public class MonsterCreationSystemShould
    {
        private readonly Mock<IGamePresenter> gamePresenter = new();
        private readonly IMonsterCreationSystem monsterCreationSystem;

        public MonsterCreationSystemShould()
        {
            monsterCreationSystem = new MonsterCreationSystem();
        }

        [Fact]
        public void CreateMultiple()
        {
            // Given
            var seeds = new int[] { 1111, -122, 5656 };

            // When
            var results = monsterCreationSystem.CreateMultiple(3, seeds).ToArray();

            // Then
            gamePresenter.VerifyAll();
            Assert.NotNull(results);
            Assert.NotEmpty(results);

            Assert.Equal("", results[0].Name.Prefix);
            Assert.Equal("Gendrid", results[0].Name.FirstName);
            Assert.Equal("Gofer", results[0].Name.Surname);
            Assert.Equal("", results[0].Name.Suffix);
            Assert.Equal("Henchman", results[0].Race.Name);

            Assert.Equal("", results[1].Name.Prefix);
            Assert.Equal("Fodark", results[1].Name.FirstName);
            Assert.Equal("Genshin", results[1].Name.Surname);
            Assert.Equal("", results[1].Name.Suffix);
            Assert.Equal("Henchman", results[1].Race.Name);

            Assert.Equal("", results[2].Name.Prefix);
            Assert.Equal("Fodark", results[2].Name.FirstName);
            Assert.Equal("Genshin", results[2].Name.Surname);
            Assert.Equal("", results[2].Name.Suffix);
            Assert.Equal("Henchman", results[2].Race.Name);
        }
    }
}