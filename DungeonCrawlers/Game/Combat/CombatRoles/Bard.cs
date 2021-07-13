using System.Collections.Generic;
using DungeonCrawlers.Contracts.Game.Combat;
using DungeonCrawlers.Game.Combat.CombatAbilities;

namespace DungeonCrawlers.Game.Combat.CombatRoles
{
    public class Bard : CombatRole
    {
        public Bard()
        {
            Name = nameof(Bard);
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