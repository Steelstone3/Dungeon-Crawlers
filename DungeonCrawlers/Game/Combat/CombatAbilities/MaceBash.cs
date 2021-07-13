using System;
using DungeonCrawlersTests.Game.Combat.DamageTypes;

namespace DungeonCrawlers.Game.Combat.CombatAbilities
{
    public class MaceBash : CombatAbility
    {
        public MaceBash()
        {
            Name = nameof(MaceBash);
            Description = string.Empty;
            Damage = new Random().Next(4, 8);
            DamageType = new Blugeoning();
        }
    }
}