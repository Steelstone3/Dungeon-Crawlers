using System.Collections.Generic;
using DungeonCrawlers.Assets;
using DungeonCrawlers.Components;
using DungeonCrawlers.Entities;
using DungeonCrawlers.Entities.Intefaces;
using DungeonCrawlers.Presenters.Interfaces;
using Spectre.Console;

namespace DungeonCrawlers.Presenters
{
    public class CharacterPresenter : ICharacterPresenter
    {
        private readonly IPresenter presenter;

        public CharacterPresenter(IPresenter presenter)
        {
            this.presenter = presenter;
        }

        public ICharacter CreateCharacter()
        {
            presenter.Print("Character creation");

            var selectedRace = presenter.SelectString("Enter race:", RaceNames.Races);

            presenter.Print($"Selected race: {selectedRace}");

            return new Character(
                new Name(
                    presenter.GetString("Enter first name:"),
                    presenter.GetString("Enter surname:")
                ),
                new Race(selectedRace),
                new Health(100, 100, 25), new Armour(100, 100, 5),
                new Weapon(presenter.GetString("Enter a weapon name:"), presenter.GetString("Describe the weapon's attack:"), 5, 1)
            );
        }

        public void PrintParty(IEnumerable<ICharacter> characters)
        {
            Table characterPartytable = presenter.CreateTable();
            characterPartytable.Title("Character Party");
            characterPartytable.AddColumn("Armour");
            characterPartytable.AddColumn("Expierence");

            foreach (ICharacter character in characters)
            {
                Markup name = new($"{character.Name.FirstName} {character.Name.Surname}");
                Markup race = new(character.Race.Name);
                Markup health = new($"[red]♥ {character.Health.CurrentHealth}/{character.Health.MaximumHealth} ♥[/]");
                Markup armour = new($"[yellow]{character.Armour.CurrentArmour}/{character.Armour.MaximumArmour}[/]");
                Markup expierence = new("↑ 0xp");
                Markup[] row = new Markup[] { name, race, health, armour, expierence };

                characterPartytable.AddRow(row);
            }

            presenter.Print(characterPartytable);
        }

        public void PrintParty(IEnumerable<IMonster> monsters)
        {
           Table monsterPartyTable = presenter.CreateTable();
            monsterPartyTable.Title("Monster Party");

            foreach (IMonster monster in monsters)
            {
                Markup name = new($"{monster.Name.FirstName}");
                Markup race = new(monster.Race.Name);
                Markup health = new($"[red]♥ {monster.Health.CurrentHealth}/{monster.Health.MaximumHealth} ♥[/]");
                Markup[] row = new Markup[] { name, race, health };

                monsterPartyTable.AddRow(row);
            }

            presenter.Print(monsterPartyTable);
        }
    }
}