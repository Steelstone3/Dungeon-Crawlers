using DungeonCrawlers.Game.Combat.DamageEffects;

namespace DungeonCrawlers.Game.Combat.DamageTypes
{
    public class ElementalFire : DamageType
    {
        public ElementalFire()
        {
            Name = nameof(ElementalFire.GetType);
            Description = "Elemental fire that has a burning effect";
            DamageEffect = new Burning();
        }
    }
}