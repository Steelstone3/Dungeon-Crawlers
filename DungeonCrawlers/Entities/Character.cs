using DungeonCrawlers.Components;

namespace DungeonCrawlers.Entities
{
    public class Character : ICharacter
    {
        public Character(IName name, IRace race)
        {
            Name = name;
            Race = race;
        }

        public IName Name { get; }
        public IRace Race { get; }
    }
}