using DungeonCrawlers.Contracts.Combat;

namespace DungeonCrawlers.Game.Combat.DamageEffects
{
    public abstract class DamageEffect : IDamageEffect
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
    }
}