using Xunit;

namespace DungeonCrawlersTests.Components
{
    public class HealthShould
    {
        private const byte MAXIMUM_HEALTH = 100;
        private const byte CURRENT_HEALTH = 100;
        private const byte REGENERATION_RATE = 25;
        private readonly IHealth health;

        public HealthShould()
        {
            health = new Health(CURRENT_HEALTH, MAXIMUM_HEALTH, REGENERATION_RATE);
        }

        [Fact]
        public void ContainsCurrentHealthPoints()
        {
            // Then
            Assert.Equal(CURRENT_HEALTH, health.CurrentHealth);
        }

        [Fact]
        public void ContainsMaximumHealthPoints()
        {
            // Then
            Assert.Equal(MAXIMUM_HEALTH, health.MaximumHealth);

        }

        [Fact]
        public void ContainsRegenerationRate()
        {
            // Then
            Assert.Equal(REGENERATION_RATE, health.RegenerationRate);
        }
    }
}