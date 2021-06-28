using System.Linq;
using DungeonCrawlers.Entities.Intefaces;
using DungeonCrawlers.Presenters.Interfaces;
using DungeonCrawlers.Systems;
using DungeonCrawlers.Systems.Interfaces;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Systems
{
    public class CharacterCreationSystemShould
    {
        private readonly Mock<ICharacterPresenter> gamePresenter = new();
        private readonly Mock<ICharacter> character = new();
        private readonly ICharacterCreationSystem characterCreationSystem;

        public CharacterCreationSystemShould()
        {
            characterCreationSystem = new CharacterCreationSystem(gamePresenter.Object);
        }

        [Fact]
        public void Create()
        {
            // Given
            gamePresenter.Setup(gp => gp.CreateCharacter()).Returns(character.Object);

            // When
            var result = characterCreationSystem.Create();

            // Then
            gamePresenter.VerifyAll();
            Assert.NotNull(result);
        }

        [Fact]
        public void CreateMultiple()
        {
            // Given
            var seeds = new int[] { 1111, -122, 5656 };

            // When
            var results = characterCreationSystem.CreateMultiple(3, seeds).ToArray();

            // Then
            gamePresenter.VerifyAll();
            Assert.NotNull(results);
            Assert.NotEmpty(results);

            Assert.Equal("Kontas", results[0].Name.FirstName);
            Assert.Equal("Katz", results[0].Name.Surname);
            Assert.Equal("Half-Elf", results[0].Race.Name);
            Assert.Equal("Halbeard", results[0].Weapon.Name);
            Assert.Equal("Hacked", results[0].Weapon.AttackDescription);

            Assert.Equal("Baakshi", results[1].Name.FirstName);
            Assert.Equal("Albertine", results[1].Name.Surname);
            Assert.Equal("Bunny-Folk", results[1].Race.Name);
            Assert.Equal("Axe", results[1].Weapon.Name);
            Assert.Equal("Bashed", results[1].Weapon.AttackDescription);

            Assert.Equal("Hemm", results[2].Name.FirstName);
            Assert.Equal("Fox", results[2].Name.Surname);
            Assert.Equal("Giant", results[2].Race.Name);
            Assert.Equal("Dagger", results[2].Weapon.Name);
            Assert.Equal("Booped", results[2].Weapon.AttackDescription);
        }
    }
}