using System.Collections.Generic;
using DungeonCrawlers.Contracts.Game.Combat;

namespace DungeonCrawlers.Game.Combat.CombatRoles
{
    public abstract class CombatRole : ICombatRole
    {
        public int Health {get; set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public IList<ICombatAbility> CombatAbilities { get; protected set; }
    }
}