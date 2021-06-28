using System.Collections.Generic;
using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Character;
using DungeonCrawlers.Contracts.Combat;
using DungeonCrawlers.Contracts.Helper;
using DungeonCrawlers.Game.Characters;
using DungeonCrawlers.Game.CombatClasses;
using System.Linq;

namespace DungeonCrawlers.Controllers.Characters
{
    public class CharacterBuilder
    {
        private IGenericDisplayHelper _genericDisplayHelper;

        public CharacterBuilder(IGenericDisplayHelper genericDisplayHelper)
        {
            _genericDisplayHelper = genericDisplayHelper;
        }

        public ICharacter BuildCharacter()
        {
            var characterName = GetCharacterName();
            var combatClass = GetCombatClass();
            return new Character(characterName);
        }

        private string GetCharacterName()
        {
            return _genericDisplayHelper.ReadUserText("Enter character's name:");
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
            return null;
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