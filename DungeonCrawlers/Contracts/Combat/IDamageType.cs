using DungeonCrawlers.Contracts.General;

namespace DungeonCrawlers.Contracts.Combat
{
    public interface IDamageType : IHeader
    {
        IDamageEffect DamageEffect { get; }
    }
}