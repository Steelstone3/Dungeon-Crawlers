using DungeonCrawlers.Contracts.Game.Characters.Race;
using DungeonCrawlers.Contracts.Game.Combat;
using DungeonCrawlers.Contracts.Helpers;

namespace DungeonCrawlers.Contracts.Game.Characters
{
    public interface ICharacter
    {
        IRace CharacterRace { get; }
        ICombatRole CombatClass { get; }
    }
}