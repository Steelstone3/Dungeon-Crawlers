using DungeonCrawlers.Game.Combat.DamageTypes;

namespace DungeonCrawlers.Game.Combat.CombatAbilities
{
    public class ViolentFury : CombatAbility
    {
        public ViolentFury()
        {
            Name = nameof(ViolentFury.GetType);
            Description = "A violent array of slashing patterns that will leave your foe a blooded mess";
            DamageType = new Slashing();
            Damage = 10;
        }
    }
}