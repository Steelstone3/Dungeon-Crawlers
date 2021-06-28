using System.Collections.Generic;
using DungeonCrawlers.Contracts.Combat;

namespace DungeonCrawlers.Game.CombatClasses
{
    public abstract class CombatClass : ICombatClass
    {
        public string Name {get; protected set;}
        public string Description {get; protected set;}
        public IEnumerable<ICombatAbility> CombatAbilities {get; protected set;}
    }
}