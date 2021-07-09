using DungeonCrawlers.Contracts.Game.Characters;
using DungeonCrawlers.Contracts.Game.Characters.Race;
using DungeonCrawlers.Contracts.Game.Combat;
using DungeonCrawlers.Game.Characters.Races;
using DungeonCrawlers.Game.Combat.CombatRoles;

namespace DungeonCrawlers.Game.Characters
{
    public class Character : ICharacter
    {
        public Character(string name)
        {
            Name = name;
        }

        public Character(string name, IRace characterRace, ICombatRole combatClass)
        {
            Name = name;
            Race = characterRace;
            CombatRole = combatClass;
        }

        public string Name { get; protected set; } = "Bob";
        public string Description { get; protected set; } = "A generic description";
        public IRace Race { get; protected set; } = new Human();
        public ICombatRole CombatRole { get; protected set; } = new Knight();
    }
}