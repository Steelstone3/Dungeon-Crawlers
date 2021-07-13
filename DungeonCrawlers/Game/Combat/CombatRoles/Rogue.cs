using System.Collections.Generic;
using DungeonCrawlers.Contracts.Game.Combat;
using DungeonCrawlers.Game.Combat.CombatAbilities;

namespace DungeonCrawlers.Game.Combat.CombatRoles
{
    public class Rogue : CombatRole
    {
        public Rogue()
        {
            Name = nameof(Rogue);
            Description = string.Empty;
            Health = 20;
            CombatAbilities = new List<ICombatAbility>() 
            {
                new MaceBash(),
                new MaceBash(),
                new MaceBash(),
                new MaceBash(),
            };
        }
    }
}