using System.Collections.Generic;
using DungeonCrawlers.Contracts.General;

namespace DungeonCrawlers.Contracts.Combat
{
    public interface ICombatClass : IHeader
    {
        IEnumerable<ICombatAbility> CombatAbilities { get; }
    }
}