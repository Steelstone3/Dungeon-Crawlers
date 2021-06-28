using DungeonCrawlers.Game.Combat.DamageEffects;

namespace DungeonCrawlers.Game.Combat.DamageTypes
{
    public class Slashing : DamageType
    {
        public Slashing()
        {
            Name = nameof(Slashing.GetType);
            Description = "A slashing motion with a chance to cause the enemy to bleed";
            DamageEffect = new Bleeding();
        }
    }
}