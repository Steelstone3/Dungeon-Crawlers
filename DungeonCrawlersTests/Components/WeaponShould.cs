using DungeonCrawlers.Components;
using DungeonCrawlers.Components.Interfaces;
using Xunit;

namespace DungeonCrawlersTests.Components
{
    public class WeaponShould
    {
        private const string NAME = "Axe";
        private const string ATTACK_DESCRIPTION = "Swing";
        private const int MAXIMUM_DAMAGE = 25;
        private const int MINIMUM_DAMAGE = 5;
        private readonly IWeapon weapon;

        public WeaponShould()
        {
            weapon = new Weapon(NAME, ATTACK_DESCRIPTION, MAXIMUM_DAMAGE, MINIMUM_DAMAGE);
        }

        [Fact]
        public void ContainName()
        {
            // Then
            Assert.Equal(NAME, weapon.Name);
        }

        [Fact]
        public void ContainAttackDescription()
        {
            // Then
            Assert.Equal(ATTACK_DESCRIPTION, weapon.AttackDescription);
        }

        [Fact]
        public void ContainMaximumDamage()
        {
            // Then
            Assert.Equal(MAXIMUM_DAMAGE, weapon.MaximumDamage);
        }

        [Fact]
        public void ContainMinimumDamage()
        {
            // Then
            Assert.Equal(MINIMUM_DAMAGE, weapon.MinimumDamage);
        }
    }
}