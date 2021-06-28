using DungeonCrawlers.Game.Combat.DamageTypes;

namespace DungeonCrawlers.Game.Combat.CombatAbilities
{
    public class Fireball : CombatAbility
    {
        public Fireball()
        {
            Name = nameof(Fireball.GetType);
            Description = "A explosive fiery ball of elemental fire";
            DamageType = new ElementalFire();
            Damage = 10;
        }
    }
}