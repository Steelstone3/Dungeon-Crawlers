using DungeonCrawlers.Contracts.Game.Combat;
using DungeonCrawlersTests.Game.Combat.DamageTypes;

namespace DungeonCrawlers.Game.Combat.CombatAbilities
{
    public class CombatAbility : ICombatAbility
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public int Damage { get; protected set; }
        public IDamageType DamageType { get; protected set; }
    }
}