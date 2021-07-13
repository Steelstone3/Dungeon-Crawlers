using System.Collections.Generic;
using DungeonCrawlers.Contracts.Game.Combat;
using DungeonCrawlers.Game.Combat.CombatAbilities;

namespace DungeonCrawlers.Game.Combat.CombatRoles
{
    public class Wizard : CombatRole
    {
        public Wizard()
        {
            Name = nameof(Wizard);
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