using System.Collections.Generic;
using DungeonCrawlers.Contracts.Combat;
using DungeonCrawlers.Game.Combat.CombatAbilities;

namespace DungeonCrawlers.Game.CombatClasses
{
    public class Knight : CombatClass
    {
        public Knight()
        {
            Name = nameof(Knight);
            Description = "A fierce defensive and heavily armoured soldier";
            CombatAbilities = new List<ICombatAbility>(){
                new ViolentFury(),
            };
        }
    }
}