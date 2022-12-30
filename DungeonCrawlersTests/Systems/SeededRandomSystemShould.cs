using System.Linq;
using DungeonCrawlers.Systems;
using Xunit;

namespace DungeonCrawlersTests.Systems
{
    public class SeededRandomSystemShould
    {
        private readonly SeededRandomSystem random = new();

        [Theory]
        [InlineData(1111, 87)]
        [InlineData(-122, 11)]
        [InlineData(5656, 62)]
        public void Create(int seed, ulong result)
        {
            // When
            var actualResult = random.GetSeededRandom(seed, byte.MinValue, byte.MaxValue);

            // Then
            Assert.Equal(result, actualResult);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(7)]
        [InlineData(25)]
        public void CreateSeeds(int quantity)
        {
            // When
            var seeds = random.CreateSeeds(quantity);

            // Then
            Assert.NotNull(seeds);
            Assert.NotEmpty(seeds);
            Assert.Equal(quantity, seeds.Length);
        }
    }
}