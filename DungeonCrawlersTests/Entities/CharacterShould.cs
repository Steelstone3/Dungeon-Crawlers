using DungeonCrawlers.Components;
using DungeonCrawlers.Entities;
using Moq;
using Xunit;

namespace DungeonCrawlersTests.Entities
{
    public class CharacterShould
    {
        private readonly Mock<IName> name = new();
        private readonly Mock<IRace> race = new();
        private readonly Mock<IHealth> health = new();
        private readonly Mock<IArmour> armour = new();
        private readonly Mock<IWeapon> weapon = new();
        private readonly ICharacter character;

        public CharacterShould()
        {
            character = new Character
            (
                name.Object,
                race.Object,
                health.Object,
                armour.Object,
                weapon.Object
            );
        }

        [Fact]
        public void ContainsCharacterName()
        {
            // Then
            Assert.NotNull(character.Name);
        }

        [Fact]
        public void ContainsCharacterRace()
        {
            // Then
            Assert.NotNull(character.Race);
        }

        [Fact]
        public void ContainsCharacterHealth()
        {
            // Then
            Assert.NotNull(character.Health);
        }

        [Fact]
        public void ContainsCharacterArmour()
        {
            // Then
            Assert.NotNull(character.Armour);
        }

        [Fact]
        public void ContainsCharacterWeapon()
        {
            // Then
            Assert.NotNull(character.Weapon);
        }
    }
}