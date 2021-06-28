using DungeonCrawlers.Contracts.Combat;
using DungeonCrawlers.Contracts.General;

namespace DungeonCrawlers.Game.CombatClasses.CombatAbilities
{
    public abstract class CombatAbility : ICombatAbility, IHeader
    {
        public IDamageType DamageType {get;protected set;}
        public int Damage {get;protected set;}
        public string Name {get; protected set;}
        public string Description {get; protected set;}
    }
}