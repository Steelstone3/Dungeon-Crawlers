using DungeonCrawlers.Game.Combat.DamageTypes;
using DungeonCrawlers.Game.CombatClasses.CombatAbilities;

namespace DungeonCrawlers.Game.CombatClasses
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