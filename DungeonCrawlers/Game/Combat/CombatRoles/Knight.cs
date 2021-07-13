using System.Collections.Generic;
using DungeonCrawlers.Contracts.Game.Combat;
using DungeonCrawlers.Game.Combat.CombatAbilities;

namespace DungeonCrawlers.Game.Combat.CombatRoles
{
    public class Knight : CombatRole
    {
        public Knight()
        {
            Name = nameof(Knight);
            Description = string.Empty;
            Health = 30;
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