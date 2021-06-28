using System.Collections.Generic;
using DungeonCrawlers.Contracts.Combat;

namespace DungeonCrawlers.Game.CombatClasses
{
    public class Wizard : CombatClass
    {
        public Wizard()
        {
            Name = nameof(Knight.GetType);
            Description = "A fierce defensive and heavily armoured soldier";
            CombatAbilities = new List<ICombatAbility>(){
                new Fireball(),
            };
        }
    }
}