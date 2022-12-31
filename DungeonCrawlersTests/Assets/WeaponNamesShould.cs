using DungeonCrawlers.Assets;
using Xunit;

namespace DungeonCrawlersTests.Assets
{
    public class WeaponNamesShould
    {
        [Fact]
        public void ContainWeaponNames()
        {
            // Then
            Assert.NotEmpty(WeaponNames.Names);
        }

        [Theory]
        [InlineData(1111, "Halbeard")]
        [InlineData(-122, "Axe")]
        [InlineData(5656, "Dagger")]
        public void GetRandomWeapon(int seed, string randomName)
        {
            // When
            string race = WeaponNames.GetRandomName(seed);

            // Then
            Assert.Equal(randomName, race);
        }

        [Fact]
        public void ContainWeaponDescription()
        {
            // Then
            Assert.NotEmpty(WeaponNames.Descriptions);
        }

        [Theory]
        [InlineData(1111, "Hacked")]
        [InlineData(-122, "Bashed")]
        [InlineData(5656, "Booped")]
        public void GetRandomWeaponDescription(int seed, string randomName)
        {
            // When
            string race = WeaponNames.GetRandomDescription(seed);

            // Then
            Assert.Equal(randomName, race);
        }
    }
}