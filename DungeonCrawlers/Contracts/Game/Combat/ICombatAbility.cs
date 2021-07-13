using DungeonCrawlers.Contracts.Helpers;
using DungeonCrawlersTests.Game.Combat.DamageTypes;

namespace DungeonCrawlers.Contracts.Game.Combat
{
    public interface ICombatAbility : IHeader
    {
        int Damage { get; }
        IDamageType DamageType { get; }
    }
}