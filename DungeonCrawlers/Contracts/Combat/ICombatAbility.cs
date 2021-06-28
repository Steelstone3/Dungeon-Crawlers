using DungeonCrawlers.Contracts.General;

namespace DungeonCrawlers.Contracts.Combat
{
    public interface ICombatAbility : IHeader
    {
        IDamageType DamageType { get; }
        int Damage { get; }
    }
}