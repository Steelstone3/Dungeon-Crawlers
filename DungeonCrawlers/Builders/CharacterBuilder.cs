using System.Collections.Generic;
using System.Linq;
using DungeonCrawlers.Contracts;
using DungeonCrawlers.Contracts.Builders;
using DungeonCrawlers.Contracts.Game.Characters.Race;
using DungeonCrawlers.Contracts.Game.Combat;
using DungeonCrawlers.Game.Characters;
using DungeonCrawlers.Game.Characters.Races;
using DungeonCrawlers.Game.Combat.CombatRoles;

namespace DungeonCrawlers.Builders
{
    public class CharacterBuilder : ICharacterBuilder
    {
        public ICharacter BuildCharacter(IDisplayer displayer)
        {
            var name = EnterCharacterName(displayer);
            var race = EnterRace(displayer);
            var combatRole = EnterCombatRole(displayer);
            return new Character(name, race, combatRole);
        }

        public IList<ICharacter> BuildCharacterParty()
        {
            throw new System.NotImplementedException();
        }

        private string EnterCharacterName(IDisplayer displayer)
        {
            return displayer.ReadString("Enter character's name:");
        }

        private IRace EnterRace(IDisplayer displayer)
        {
            var raceMenu = CreateRaceMenu();
            var convertedRaceMenu = (raceMenu.Select(item => item.Name)).ToList();

            displayer.WriteMenu(convertedRaceMenu);
            var raceSelection = displayer.ReadNumeric("Enter character's race:", 0, 2);

            return raceMenu[raceSelection];
        }

        private ICombatRole EnterCombatRole(IDisplayer displayer)
        {
            var combatRoleMenu = CreateCombatRoleMenu();
            var convertedCombatRoleMenu = (combatRoleMenu.Select(item => item.Name)).ToList();

            displayer.WriteMenu(convertedCombatRoleMenu);
            var combatRoleSelection = displayer.ReadNumeric("Enter character's combat role:", 0, 3);

            return combatRoleMenu[combatRoleSelection];
        }

        private IList<IRace> CreateRaceMenu()
        {
            return new List<IRace>()
            {
                new Dwarf(),
                new Elf(),
                //new Gnome(),
                //new HalfElf(),
                //new HalfGiant(),
                //new Halfling(),
                //new HalfOrc(),
                new Human(),
                //new Lizardfolk(),
                //new Orc(),
                //new Wolfen(),
            };
        }

        private List<ICombatRole> CreateCombatRoleMenu()
        {
            return new List<ICombatRole>()
            {
                new Bard(),
                new Knight(),
                new Rogue(),
                new Wizard(),
            };
        }
    }
}