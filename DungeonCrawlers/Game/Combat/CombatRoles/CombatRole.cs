using DungeonCrawlers.Contracts.Game.Combat;
using DungeonCrawlers.Contracts.Helpers;

namespace DungeonCrawlers.Game.Combat.CombatRoles
{
    public abstract class CombatRole : ICombatRole
    {
        public string Name { get; protected set; }

        public string Description { get; protected set; }
    }
}