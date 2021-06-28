using DungeonCrawlers.Game.CombatClasses;
using DungeonCrawlers.Game.CombatClasses.CombatAbilities;
using Xunit;

namespace DungeonCrawlersTests
{
    public class CombatAbilitiesShould
    {
        [Fact]
        public void ContainHeaderDamageAndDamageTypeForViolentFury()
        {
            var violentFury = new ViolentFury();

            Assert.NotNull(violentFury.Name);
            Assert.NotNull(violentFury.Description);
            Assert.NotNull(violentFury.DamageType);
            Assert.NotInRange(violentFury.Damage, int.MinValue, 0);
        }

         [Fact]
        public void ContainHeaderDamageAndDamageTypeForFireball()
        {
            var fireball = new Fireball();

            Assert.NotNull(fireball.Name);
            Assert.NotNull(fireball.Description);
            Assert.NotNull(fireball.DamageType);
            Assert.NotInRange(fireball.Damage, int.MinValue, 0);
        }
    }
}