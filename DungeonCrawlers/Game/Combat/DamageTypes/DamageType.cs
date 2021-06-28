using DungeonCrawlers.Contracts.Combat;

namespace DungeonCrawlers.Game.Combat.DamageTypes
{
    public abstract class DamageType : IDamageType
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public IDamageEffect DamageEffect { get; protected set; }
    }
}