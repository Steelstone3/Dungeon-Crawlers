using System.Collections.Generic;
using DungeonCrawlers.Contracts.Helpers;

namespace DungeonCrawlers.Contracts.Game.Combat
{
    public interface ICombatRole : IHeader
    {
        int Health { get; set; }
        IList<ICombatAbility> CombatAbilities {get;}
    }
}