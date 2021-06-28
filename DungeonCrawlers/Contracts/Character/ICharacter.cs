using DungeonCrawlers.Contracts.Combat;
using DungeonCrawlers.Contracts.General;

namespace DungeonCrawlers.Contracts.Character
{
    public interface ICharacter : IHeader
    {
        ICharacterRace CharacterRace { get; }
        ICombatClass CombatClass { get; }
    }
}