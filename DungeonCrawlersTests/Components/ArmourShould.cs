using DungeonCrawlers.Components;
using DungeonCrawlers.Components.Interfaces;
using Xunit;

namespace DungeonCrawlersTests.Components
{
    public class ArmourShould
    {
        private const byte MAXIMUM_ARMOUR = 100;
        private const byte CURRENT_ARMOUR = 100;
        private const byte REPAIR_RATE = 5;
        private readonly IArmour armour;

        public ArmourShould()
        {
            armour = new Armour(CURRENT_ARMOUR, MAXIMUM_ARMOUR, REPAIR_RATE);
        }

        [Fact]
        public void ContainsCurrentHealthPoints()
        {
            // Then
            Assert.Equal(CURRENT_ARMOUR, armour.CurrentArmour);
        }

        [Fact]
        public void ContainsMaximumHealthPoints()
        {
            // Then
            Assert.Equal(MAXIMUM_ARMOUR, armour.MaximumArmour);
        }

        [Fact]
        public void ContainsRegenerationRate()
        {
            // Then
            Assert.Equal(REPAIR_RATE, armour.RepairRate);
        }
    }
}