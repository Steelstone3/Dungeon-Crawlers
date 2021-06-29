using System.Collections.Generic;
using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Character;
using DungeonCrawlers.Contracts.Combat;
using DungeonCrawlers.Contracts.Helper;
using DungeonCrawlers.Game.Characters;
using DungeonCrawlers.Game.CombatClasses;
using System.Linq;
using DungeonCrawlers.Game.Characters.CharacterRaces;

namespace DungeonCrawlers.Controllers.Characters
{
    public class CharacterBuilder : ICharacterBuilder
    {
        private IGenericDisplayHelper _genericDisplayHelper;

        public CharacterBuilder(IGenericDisplayHelper genericDisplayHelper)
        {
            _genericDisplayHelper = genericDisplayHelper;
        }

        public ICharacter BuildCharacter()
        {
            var characterName = GetCharacterName();
            var characterRace = GetCharacterRace();
            var combatClass = GetCombatClass();
            return new Character(characterName, characterRace, combatClass);
        }

        public ICharacter BuildRandomCharacter(int nameSeed, int characterRaceSeed, int combatClassSeed)
        {
            var characterNameMenu = CreateCharacterNameMenu();
            var characterRaceMenu = CreateCharacterRaceMenu();
            var combatClassMenu = CreateCombatClassMenu();
            return new Character(characterNameMenu[nameSeed], characterRaceMenu[characterRaceSeed], combatClassMenu[combatClassSeed]);
        }

        private string GetCharacterName()
        {
            return _genericDisplayHelper.ReadUserString("Enter character's name:");
        }

        private ICombatClass GetCombatClass()
        {
            var combatClassMenu = CreateCombatClassMenu();
            var convertedCombatClassMenu = (combatClassMenu.Select(item => item.Name)).ToList();

            _genericDisplayHelper.DisplayMenu(convertedCombatClassMenu);

            var value = _genericDisplayHelper.ReadUserNumericInput("Select combat class:", 0, 1);

            return combatClassMenu[value];
        }

        private ICharacterRace GetCharacterRace()
        {
            var characterRaceMenu = CreateCharacterRaceMenu();
            var convertedCharacterRaceMenu = (characterRaceMenu.Select(item => item.Name)).ToList();

            _genericDisplayHelper.DisplayMenu(convertedCharacterRaceMenu);

            var value = _genericDisplayHelper.ReadUserNumericInput("Select character race:", 0, 9);

            return characterRaceMenu[value];
        }

        private List<string> CreateCharacterNameMenu()
        {
            return new List<string>()
            {
                "Alex",
                "Jimbo",
                "Fred",
                "Bob",
                "Sally",
                "Lucy",
                "Chloe",
                "Dave",
                "Jeff",
            };
        }

        private List<ICharacterRace> CreateCharacterRaceMenu()
        {
            return new List<ICharacterRace>()
            {
                new Dwarf(),
                new Elf(),
                new Gnome(),
                new HalfElf(),
                new HalfGiant(),
                new Halfling(),
                new HalfOrc(),
                new Human(),
                new Lizardfolk(),
                new Orc(),
                new Wolfen(),
            };
        }

        private List<ICombatClass> CreateCombatClassMenu()
        {
            return new List<ICombatClass>()
            {
                new Knight(),
                new Wizard(),
            };
        }
    }
}