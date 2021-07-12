using DungeonCrawlers.Contracts.Game.Characters.Race;
using DungeonCrawlers.Contracts.Game.Combat;
using DungeonCrawlers.Contracts.Helpers;

namespace DungeonCrawlers.Contracts.Game.Characters
{
    public interface ICharacter : IHeader
    {
        IRace Race { get; }
        ICombatRole CombatRole { get; }
        //IList<ICombatAbility> CombatAbilities { get; }
    }
}