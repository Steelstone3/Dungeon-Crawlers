using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.General;

namespace DungeonCrawlers.Game.Characters.CharacterRaces
{
    public abstract class CharacterRace : ICharacterRace, IHeader
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
    }
}