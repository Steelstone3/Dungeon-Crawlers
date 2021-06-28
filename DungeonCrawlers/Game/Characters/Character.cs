using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Character;
using DungeonCrawlers.Contracts.Combat;
using DungeonCrawlers.Game.CharacterRaces;
using DungeonCrawlers.Game.CombatClasses;

namespace DungeonCrawlersTests
{
    public class Character : ICharacter
    {
        public Character()
        {

        }

        public Character(string name)
        {
            Name = name;
        }

        public Character(ICharacterRace characterRace)
        {
            CharacterRace = characterRace;
        }

        public Character(ICombatClass combatClass)
        {
            CombatClass = combatClass;
        }

        public Character(ICharacterRace characterRace, ICombatClass combatClass)
        {
            CharacterRace = characterRace;
            CombatClass = combatClass;
        }

        public Character(string name, ICharacterRace characterRace, ICombatClass combatClass)
        {
            Name = name;
            CharacterRace = characterRace;
            CombatClass = combatClass;
        }

        public string Name { get; set; } = "Bob";
        public string Description { get; set; } = "A generic description";
        public ICharacterRace CharacterRace { get; set; } = new Human();
        public ICombatClass CombatClass { get; set; } = new Knight();
    }
}